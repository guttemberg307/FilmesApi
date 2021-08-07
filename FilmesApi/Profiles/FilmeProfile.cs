using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {   
         public FilmeProfile()
        {
                    //converte -------para 
            CreateMap<CreateFilmeDto, Filme>();// CreateMap</converte,para>
            CreateMap<Filme,ReadFilmeDto>();
            CreateMap<UptateFilmeDto, Filme>();

        }  
    }
}
