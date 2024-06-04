using CinePlayers.Data;
using CinePlayers.Enums;
using CinePlayers.Models;
using CinePlayers.ViewModels;
using CinePlayers.ViewModels.Filmes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinePlayers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly CinePlayersDataContext _context;

        public FilmeController(CinePlayersDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var filmes = await _context.Filmes.OrderBy(x => x.Nome).ToListAsync();
                return Ok(new ResultViewModel<List<Filme>>(filmes));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("Falha interna no servidor"));
            }
        }

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetByNameAsync(string nome)
        {
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Nome == nome);

                if (filme is null)
                    return NotFound(new ResultViewModel<Filme>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("Falha interna no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateFilmeViewModel model)
        {
            try
            {
                var filme = new Filme(model.Nome, model.Elenco, model.Diretor, model.Duracao, model.AnoDeLancamento,
                    model.Sinopse, model.AvaliacaoDosCriticos, model.AvaliacaoDosUsuarios, model.Tag, model.Categoria, model.Imagem);

                await _context.Filmes.AddAsync(filme);
                await _context.SaveChangesAsync();

                return Created($"Filme/{filme.Id}", new ResultViewModel<Filme>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateFilmeViewModel model)
        {
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);

                if (filme is null)
                    return NotFound(new ResultViewModel<Filme>("Conteudo não encontrado"));

                filme.Alterar(model);

                _context.Filmes.Update(filme);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);

                if (filme is null)
                    return NotFound(new ResultViewModel<Filme>("Conteudo não encontrado"));

                _context.Filmes.Remove(filme);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Filme>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpPost("Reagir")]
        public async Task<IActionResult> ReactionToMovieAsync(Guid idFilme, Guid idUsuario, EReacoesFilme tipoReacao)
        {
            try
            {
                var usuario = await _context
                    .Usuarios
                    .Include(x => x.FilmesFavoritos)
                    .Include(x => x.FilmesReagidos)
                        .ThenInclude(x => x.Filme)
                    .Include(x => x.FilmesAvaliados)
                    .FirstOrDefaultAsync(x => x.Id == idUsuario);

                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == idFilme);

                if (usuario is null || filme is null)
                    return NotFound(new ResultViewModel<Filme>("Conteudo não encontrado"));

                var reacaoExistente = usuario.FilmesReagidos.FirstOrDefault(x => x.Filme.Id == filme.Id);

                if (reacaoExistente is not null)
                    _context.ReacoesFilmes.Remove(reacaoExistente);

                var reacao = new ReacoesFilme(usuario, filme, tipoReacao);

                await _context.ReacoesFilmes.AddAsync(reacao);
                await _context.SaveChangesAsync();
                await AtualizarReacaoFilme(filme);

                return Ok(new ResultViewModel<string>($"{filme.Nome} reagido com sucesso", null));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpPost("Critico")]
        public async Task<IActionResult> RateMovieAsync(Guid idFilme, Guid idUsuario, double nota)
        {
            try
            {
                if (!(nota >= 0 && nota <= 10))
                    return BadRequest(new ResultViewModel<Filme>("Nota Invalida"));

                var usuario = await _context
                    .Usuarios
                    .Include(x => x.FilmesFavoritos)
                    .Include(x => x.FilmesReagidos)
                    .Include(x => x.FilmesAvaliados)
                    .FirstOrDefaultAsync(x => x.Id == idUsuario);

                var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == idFilme);

                if (usuario is null || filme is null)
                    return NotFound(new ResultViewModel<Filme>("Conteudo não encontrado"));

                var avaliacoesExistentes = usuario.FilmesAvaliados.FirstOrDefault(x => x.Filme.Id == filme.Id);

                if (avaliacoesExistentes is not null)
                    _context.AvaliacoesFilmes.Remove(avaliacoesExistentes);

                var avaliacao = new AvaliacoesFilme(usuario, filme, nota);

                await _context.AvaliacoesFilmes.AddAsync(avaliacao);
                await _context.SaveChangesAsync();
                await AtualizarAvaliacaoFilme(filme);

                return Ok(new ResultViewModel<string>($"{filme.Nome} avaliado com sucesso", null));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpGet("BuscarReacoes")]
        public async Task<IActionResult> GetMoviesReactionAsync(Guid idFilme)
        {
            try
            {
                var reacoesDoFilme = await _context.ReacoesFilmes
                    .Where(x => x.Filme.Id == idFilme)
                    .ToListAsync();

                if (reacoesDoFilme.Count == 0)
                    return NotFound(new ResultViewModel<Filme>("Não encontrado"));

                var likes = reacoesDoFilme.Count(x => x.Reacoes == EReacoesFilme.Like);
                var dislikes = reacoesDoFilme.Count(x => x.Reacoes == EReacoesFilme.Dislike);

                var result = new GetMoviesReactionViewModel
                {
                    Likes = likes,
                    Dislikes = dislikes
                };

                return Ok(new ResultViewModel<GetMoviesReactionViewModel>(result));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Filme>("Falha interna no servidor"));
            }
        }

        [HttpGet("Lancamentos")]
        public async Task<IActionResult> GetByReleaseAsync()
        {
            try
            {
                var filme = await _context.Filmes.OrderByDescending(x => x.AnoDeLancamento).Take(6).ToListAsync();

                if (filme is null)
                    return NotFound(new ResultViewModel<List<Filme>>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<List<Filme>>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("Falha interna no servidor"));
            }
        }

        [HttpGet("MaisCurtidos")]
        public async Task<IActionResult> GetByMoreLikesAsync()
        {
            try
            {
                var filmesMaisCurtidos = await _context.ReacoesFilmes
                    .Where(x => x.Reacoes == EReacoesFilme.Like)
                    .GroupBy(x => x.Filme)
                    .Select(group => new
                    {
                        Filme = group.Key,
                        Likes = group.Count()
                    })
                    .OrderByDescending(x => x.Likes)
                    .Select(x => x.Filme)
                    .Take(6) 
                    .ToListAsync();

                if (!filmesMaisCurtidos.Any())
                    return NotFound(new ResultViewModel<string>("Nenhum filme curtido encontrado"));

                return Ok(new ResultViewModel<List<Filme>>(filmesMaisCurtidos));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("Falha interna no servidor"));
            }
        }

        [HttpGet("Destaque")]
        public async Task<IActionResult> GetBySpotlightAsync()
        {
            try
            {
                var filmesDestaque = await _context.ReacoesFilmes
                    .Where(x => x.Reacoes == EReacoesFilme.Like)
                    .GroupBy(x => x.Filme)
                    .Select(group => new
                    {
                        Filme = group.Key,
                        Likes = group.Count()
                    })
                    .OrderByDescending(x => x.Likes)
                    .ThenByDescending(x => x.Filme.AnoDeLancamento)
                    .Select(x => x.Filme)
                    .Take(6) 
                    .ToListAsync();

                if (!filmesDestaque.Any())
                    return NotFound(new ResultViewModel<string>("Nenhum filme curtido encontrado"));

                return Ok(new ResultViewModel<List<Filme>>(filmesDestaque));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("Falha interna no servidor"));
            }
        }

        [HttpGet("EmCartaz")]
        public async Task<IActionResult> GetByOnDisplayAsync()
        {
            try
            {
                var filme = await _context.Filmes
                    .Where(x => x.Tag == ETagFilme.Cartaz)
                    .Take(10)
                    .ToListAsync();

                if (filme is null)
                    return NotFound(new ResultViewModel<List<Filme>>("Conteúdo não encontrado"));

                return Ok(new ResultViewModel<List<Filme>>(filme));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<List<Filme>>("Falha interna no servidor"));
            }
        }

        private async Task AtualizarAvaliacaoFilme(Filme filme)
        {
            var avaliacoesDoFilme = await _context.AvaliacoesFilmes
                .Where(x => x.Filme.Id == filme.Id)
                .ToListAsync();

            double soma = 0;

            foreach (var item in avaliacoesDoFilme)
            {
                soma += item.Avaliacao;
            }

            double media = soma / avaliacoesDoFilme.Count;

            filme.AtualizarAvaliacaoDosUsuarios(media);

            await _context.SaveChangesAsync();
        }

        private async Task AtualizarReacaoFilme(Filme filme)
        {
            var reacoesDoFilme = await _context.ReacoesFilmes
                                .Where(x => x.Filme.Id == filme.Id)
                                .ToListAsync();

            var likes = reacoesDoFilme.Count(x => x.Reacoes == EReacoesFilme.Like);
            var dislikes = reacoesDoFilme.Count(x => x.Reacoes == EReacoesFilme.Dislike);

            filme.AtualizarReacoesDosUsuarios(likes, dislikes);

            await _context.SaveChangesAsync();
        }
    }
}
