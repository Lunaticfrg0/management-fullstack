﻿using AutoMapper;
using Business.Mappers.Dto;
using Business.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Domain.Entities;

namespace Business.Services.Repository
{
    public class ClientAddressRepository : IClientAddressRepository
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        public ClientAddressRepository(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Create(ClientAddressDto clientAddress)
        {
            try
            {
                var newClientAddress = _mapper.Map<ClientAddress>(clientAddress);
                _context.Add(newClientAddress);
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
                var currentClientAddress = await _context.ClientAddresses.FirstAsync(x => x.Id == id);
                currentClientAddress.IsDeleted = true;
                _context.Update(currentClientAddress);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<List<ClientAddressDto>> GetByClientId(Guid clientId)
        {
            var list = _mapper.Map<List<ClientAddressDto>>(await _context.ClientAddresses
                .Where(x => x.ClientId == clientId).ToListAsync());
            return list;
        }

        public async Task<ClientAddressDto> GetById(Guid id)
        {
            var clientAddress = _mapper.Map<ClientAddressDto>(_context.ClientAddresses.FirstOrDefault(x => x.Id == id));
            return clientAddress;
        }


        public async Task Update(ClientAddressDto clientAddress)
        {
            try
            {
                var currentClientAddress = await _context.ClientNumbers.FirstAsync(x => x.Id == clientAddress.Id);
                _mapper.Map(clientAddress, currentClientAddress);
                _context.Update(currentClientAddress);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }
    }
}
