using AutoMapper;
using Business.Mappers.Dto;
using Business.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Domain.Entities;

namespace Business.Services.Repository
{
    public class ClientNumberRepository : IClientNumberRepository
    {

        private readonly IMapper _mapper;
        private readonly Context _context;
        public ClientNumberRepository(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Create(ClientNumberDto clientNumber)
        {
            try
            {
                var newClientNumber = _mapper.Map<ClientNumber>(clientNumber);
                _context.Add(newClientNumber);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var currentClientNumber = await _context.ClientNumbers.FirstAsync(x => x.Id == id);
                _context.ClientNumbers.Remove(currentClientNumber);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<ClientNumberDto> GetById(Guid id)
        {
            var clientNumber = _mapper.Map<ClientNumberDto>(_context.ClientNumbers.FirstOrDefault(x => x.Id == id));
            return clientNumber;
        }

        public Task<List<ClientNumberDto>> List(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ClientNumberDto clientNumber)
        {
            try
            {
                var currentClientNumber = await _context.ClientNumbers.FirstAsync(x => x.Id == clientNumber.Id);
                _mapper.Map(clientNumber, currentClientNumber);
                _context.Update(currentClientNumber);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
