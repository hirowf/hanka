using System;
using Hanka.ApiDotNet6.Domain.Entities;
using Hanka.ApiDotNet6.Domain.Repositories;
using Hanka.ApiDotNet6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hanka.ApiDotNet6.Infra.Data.Repositories;
public class PersonRepository : IPersonRepository
{
  private readonly ApplicationDbContext _db;
  public PersonRepository(ApplicationDbContext db)
  {
    _db = db;
  }

  public async Task<Person> CreateAsync(Person person)
  {
    _db.Add(person);
    await _db.SaveChangesAsync();
    return person;
  }

  public async Task DeleteAsync(Person person)
  {
    _db.Remove(person);
    await _db.SaveChangesAsync();
  }

  public async Task EditAsync(Person person)
  {
    _db.Update(person);
    await _db.SaveChangesAsync();
  }

  public async Task<Person> GetByIdAsync(int id) => await _db.People.FirstOrDefaultAsync(x => x.Id == id);

  public async Task<ICollection<Person>> GetPeopleAsync() => await _db.People.ToListAsync();
}
