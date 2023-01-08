using Backend.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Clients;

public class ClientService : IClientService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ClientService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Models.Clients.Clients>> GetClients()
    {
        return await _context.Clients.ToListAsync();
    }
    
    public async Task<Models.Clients.Clients> GetClientByCode(string code)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(x => x.code == code);
        if (client == null)
        {
            return null;
        }

        return client;
    }
    
    public async Task<Models.Clients.Clients> CreateClient(Models.Clients.Clients client)
    {
        var clientExists = await _context.Clients.FirstOrDefaultAsync(x => x.code == client.code);
        if (clientExists != null)
        {
            return null;
        }
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Models.Clients.Clients>? UpdateClient(Models.Clients.Clients client, int id)
    {
        var clientInDb = _mapper.Map<Models.Clients.Clients>(client);
        clientInDb.Id = id;
        _context.Clients.Update(clientInDb);
        await _context.SaveChangesAsync();
        return clientInDb;
    }


    public async Task<Models.Clients.Clients>? DeleteClient(int id)
    {
        var clientToDelete = await _context.Clients.FindAsync(id);
        if (clientToDelete == null)
        {
            return null;
        }

        _context.Clients.Remove(clientToDelete);
        await _context.SaveChangesAsync();
        return clientToDelete;
    }
}