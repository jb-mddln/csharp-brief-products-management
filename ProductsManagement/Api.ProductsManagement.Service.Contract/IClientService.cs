﻿using Api.ProductsManagement.Business.Dto.Client;

namespace Api.ProductsManagement.Service.Contract
{
    public interface IClientService
    {
        Task<IEnumerable<ReadClientDto>> GetClientsAsync();

        Task<ReadClientDto> GetClientByIdAsync(int id);

        Task<ReadClientDto> AddClientAsync(CreateClientDto clientDto);
    }
}