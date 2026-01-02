using Library.ApplicationCore;
using Library.ApplicationCore.Entities;

namespace Library.Infrastructure.Data;

public class JsonPatronRepository : IPatronRepository
{
    private readonly JsonData _jsonData;

    public JsonPatronRepository(JsonData jsonData)
    {
        _jsonData = jsonData;
    }

    public async Task<List<Patron>> SearchPatrons(string searchInput)
    {
        await _jsonData.EnsureDataLoaded();

        var patrons = _jsonData.Patrons ?? new List<Patron>();
        var searchResults = patrons.Where(p => p.Name.Contains(searchInput)).OrderBy(p => p.Name).ToList();

        searchResults = _jsonData.GetPopulatedPatrons(searchResults);

        return searchResults;
    }

    public async Task<Patron?> GetPatron(int id)
    {
        await _jsonData.EnsureDataLoaded();

        return _jsonData.Patrons?.Where(p => p.Id == id).Select(p => _jsonData.GetPopulatedPatron(p)).FirstOrDefault();
    }

    public async Task UpdatePatron(Patron patron)
    {
        await _jsonData.EnsureDataLoaded();
        var existingPatron = _jsonData.Patrons?.FirstOrDefault(p => p.Id == patron.Id);
        if (existingPatron != null)
        {
            existingPatron.Name = patron.Name;
            existingPatron.ImageName = patron.ImageName;
            existingPatron.MembershipStart = patron.MembershipStart;
            existingPatron.MembershipEnd = patron.MembershipEnd;
            existingPatron.Loans = patron.Loans;
            await _jsonData.SavePatrons(_jsonData.Patrons!);
            await _jsonData.LoadData();
        }
    }
}
