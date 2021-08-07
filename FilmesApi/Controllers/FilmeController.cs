using AutoMapper;
using FilmesApi.Dado;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context,IMapper mapper)// cria o contexto entre o banco e filmeconttoller
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]// cadastra um novo filme "publicar"
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)//[FromBody] este filme que estou recebendo vem do corpo da requisição
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);// converte filmeDto em filme 

            _context.Filmes.Add(filme);// no contexto de filmes vamos adiocionar um novo filme
            _context.SaveChanges(); // salva as alterações efetivamente no banco de dados 
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }


        [HttpGet]// obtem a lista de filmes 
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;//o contexto ira acessar toda a nossa lista de filmes listados
        }


        [HttpGet("{id}")]// retornamos o parametro ("{id}") para especificar o tipo de retorno GET
        public IActionResult RecuperaFilmesPorId(int id)// IActionResult Define um contrato que representa o resultado de um método de ação.
        {

            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);// filmes.Id tem que ser igual ao id do parametro//_context.Filmes.FirstOrDefault encontra o primeiro ou o nulo da nossa lista

            if (filme != null)
            {

                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);//  converte readfilmedto para filme 
                return Ok(filmeDto);// retorna o status 200 com a lista de filmes
            }
            return NotFound(); // retorna error 404 dizendo que nao foi encontrado o filme
        }


        [HttpPut("{id}")]// HttpPut é usado para atualização/ alteração
        public IActionResult AtualizaFilme(int id, [FromBody] UptateFilmeDto filmeDto)// atualizar filme recebe id com parametro
        {

            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) // se o filme não existe restorna notfound
            {
                return NotFound();
            }

            _mapper.Map(filmeDto, filme);//converte as informações de filmeDto para fime 
            _context.SaveChanges();// salva as mudanças 
            return NoContent(); // traz uma resposta vazia status 204    
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) // se o filme não existe restorna notfound
            {
                return NotFound();
            }

            _context.Remove(filme); // deleta o filme caso encontre 
            _context.SaveChanges(); // salva as alterações 
            return NoContent();
        
        }



    }

}
