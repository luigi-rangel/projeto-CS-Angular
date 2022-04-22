using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.DTOs;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist geralPersist;
        private readonly IEventoPersist eventoPersist;
        private readonly IMapper mapper;

        public EventoService(IGeralPersist geralPersist, 
                                        IEventoPersist eventoPersist,
                                        IMapper mapper)
        {
            this.geralPersist = geralPersist;
            this.eventoPersist = eventoPersist;
            this.mapper = mapper;
        }

        public async Task<EventoDTO> AddEventos(EventoDTO model)
        {
            try
            {
                var evento = this.mapper.Map<Evento>(model);

                this.geralPersist.Add<Evento>(evento);
                if(await this.geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await this.eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    return this.mapper.Map<EventoDTO>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO> UpdateEvento(int eventoId, EventoDTO model)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId);
                if(evento == null) return null;

                model.Id = evento.Id;

                this.geralPersist.Update(this.mapper.Map<Evento>(model));
                if(await this.geralPersist.SaveChangesAsync())
                {
                    return this.mapper.Map<EventoDTO>(await this.eventoPersist.GetEventoByIdAsync(model.Id));
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId);
                if(evento == null) throw new Exception("Evento para delete não encontrado!");

                this.geralPersist.Delete(evento);
                return await this.geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await this.eventoPersist.GetAllEventosAsync(includePalestrantes);
                if(eventos == null) return null;

                var resultado = mapper.Map<EventoDTO[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await this.eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if(eventos == null) return null;

                var resultado = mapper.Map<EventoDTO[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO> GetEventoByIdAsync(int Id, bool includePalestrantes = false)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(Id, includePalestrantes);
                if(evento == null) return null;

                var resultado = this.mapper.Map<EventoDTO>(evento);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}