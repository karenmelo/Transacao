using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pagamento.App.ViewModels;
using Pagamento.Business.Integracao.Interface;
using Pagamento.Business.Integracao.Model.Request;
using Pagamento.Business.Interface;
using Pagamento.Business.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Pagamento.App.Controllers
{
    public class TransacoesController : Controller
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly ICieloApiIntegration _cieloApi;

        public TransacoesController(ITransacaoRepository transacaoRepository,
                                    IPaymentRepository paymentRepository,
                                    IMapper mapper,
                                    ICieloApiIntegration cieloApi)
        {
            _paymentRepository = paymentRepository;
            _transacaoRepository = transacaoRepository;
            _mapper = mapper;
            _cieloApi = cieloApi;
        }

        public async Task<IActionResult> Index()
        {
            var transacoes = await _transacaoRepository.ObterTodasTransacoes();
            return View(_mapper.Map<IEnumerable<TransacaoViewModel>>(transacoes));
        }

        public async Task<IActionResult> Capture(Guid id)
        {
            var transacaoViewModel = await ObterTransacao(id);

            if (transacaoViewModel == null) return NotFound();

            var result = _cieloApi.Capturar(_mapper.Map<TransactionPutRequest>(transacaoViewModel));

            var payment = await _paymentRepository.ObterPagamento(transacaoViewModel.PaymentId);

            payment.Update(_mapper.Map<Payment>(result.Objeto));

            if (result.StatusCode == (int)HttpStatusCode.OK)
                await _paymentRepository.Atualizar(payment);


            return View(transacaoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransacaoViewModel transacaoViewModel)
        {
            if (!ModelState.IsValid) return View(transacaoViewModel);

            var result = _cieloApi.Criar(_mapper.Map<TransacaoPostRequest>(transacaoViewModel));

            if (result.StatusCode == (int)HttpStatusCode.Created)
                await _transacaoRepository.Adicionar(_mapper.Map<Transaction>(result.Objeto));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Cancel(Guid id)
        {
            var transacaoViewModel = await ObterTransacao(id);

            if (transacaoViewModel == null) return NotFound();

            var result = _cieloApi.Cancelar(_mapper.Map<TransactionPutRequest>(transacaoViewModel));

            var payment = await _paymentRepository.ObterPagamento(transacaoViewModel.PaymentId);

            payment.Update(_mapper.Map<Payment>(result.Objeto));

            if (result.StatusCode == (int)HttpStatusCode.OK)
                await _paymentRepository.Atualizar(payment);


            return View(transacaoViewModel);
        }
                         
        private async Task<TransacaoViewModel> ObterTransacao(Guid id)
        {
            return _mapper.Map<TransacaoViewModel>(await _transacaoRepository.ObterTransacao(id));
        }
    }
}
