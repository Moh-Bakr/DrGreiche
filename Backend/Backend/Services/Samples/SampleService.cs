using AutoMapper;
using Backend.Data;
using Backend.Models.Sample;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Samples;

public class SampleService : ISampleService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SampleService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Sample>> GetSamples()
    {
        return await _context.Samples.ToListAsync();
    }
    
     public async Task<IEnumerable<Sample>> SearchSampleByName(string name)
    {
        return await _context.Samples.Where(x => x.client_name.Contains(name)).ToListAsync();
    }
    
    public async Task<Sample> CreateSample(Sample sample)
    {
        _context.Samples.Add(sample);
        await _context.SaveChangesAsync();
        return sample;
    }

    public async Task<Sample>? UpdateSample(Sample sample, int id)
    {
        var sampleInDb = _mapper.Map<Sample>(sample);
        sample.Id = id;
        _context.Samples.Update(sampleInDb);
        await _context.SaveChangesAsync();
        return sampleInDb;
    }


    public async Task<Sample>? DeleteSample(int id)
    {
        var sampleToDelete = await _context.Samples.FindAsync(id);
        if (sampleToDelete == null)
        {
            return null;
        }

        _context.Samples.Remove(sampleToDelete);
        await _context.SaveChangesAsync();
        return sampleToDelete;
    }
}