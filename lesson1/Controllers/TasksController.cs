using Microsoft.AspNetCore.Mvc;
using  lesson1.Models;

namespace lesson1.Controllers;

[ApiController]
[Route("[controller]")]

public class TUsController : ControllerBase
{

    private List<TU> arr;
    public TUsController()
    {
        arr = new List<TU>
        {
            new TU { Id = 1, Name = "moshe", Description = "to do homework", Perform = false },
            new TU { Id = 2, Name = "Yaakov", Description = "go work", Perform = false },
            new TU { Id = 3, Name = "Ysrael", Description = "go for a walk", Perform = true }
        };
    }


    [HttpGet]
    public IEnumerable<TU> Get()
    {
        return arr;
    }

    [HttpGet("{id}")]
    public TU Get(int id)
    {
        return arr.FirstOrDefault(t => t.Id == id);
    }

    [HttpPost]
    public int Post(TU newTU)
    {
        int max = arr.Max(p => p.Id);
        newTU.Id = max + 1;
        arr.Add(newTU);
        return newTU.Id;
    }

    [HttpPut("{id}")]
    public void Put(int id, TU newTU)
    {
        if (id == newTU.Id)
        {
            var TU = arr.Find(p => p.Id == id);
            if (TU != null)
            {
                int index = arr.IndexOf(TU);
                arr[index] = newTU;
            }
        }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var TU = arr.Find(p => p.Id == id);
        if (TU != null)
        {
            arr.Remove(TU);
        }
    }
}