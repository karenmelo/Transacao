using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pagamento.App.ViewModels;
using Pagamento.Business.Integracao.Interface;
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
        private readonly IMapper _mapper;
        private readonly ICieloApiIntegration _cieloApi;

        public TransacoesController(ITransacaoRepository transacaoRepository,
                                    IMapper mapper,
                                    ICieloApiIntegration cieloApi)
        {
            _transacaoRepository = transacaoRepository;
            _mapper = mapper;
            _cieloApi = cieloApi;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<TransacaoViewModel>>(await _transacaoRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var transacaoViewModel = await ObterTransacao(id);
            if (transacaoViewModel == null) return NotFound();

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

            var result = _cieloApi.Criar(_mapper.Map<Transacao>(transacaoViewModel));

            if(result.StatusCode == (int)HttpStatusCode.OK)
                await _transacaoRepository.Adicionar(_mapper.Map<Transacao>(transacaoViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var transacaoViewModel = await ObterTransacao(id);
            if (transacaoViewModel == null) return NotFound();

            return View(transacaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TransacaoViewModel transacaoViewModel)
        {
            if (id != transacaoViewModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(transacaoViewModel);

            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var transacaoViewModel = await ObterTransacao(id);
        //    if (transacaoViewModel == null) return NotFound();

        //    return View(transacaoViewModel);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var transacaoViewModel = await _context.TransacaoViewModel.FindAsync(id);
        //    _context.TransacaoViewModel.Remove(transacaoViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private async Task<TransacaoViewModel> ObterTransacao(Guid id)
        {
            return _mapper.Map<TransacaoViewModel>(await _transacaoRepository.ObterPorId(id));
        }

    }
}
