using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TpModul10_103022300114
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        // Menyimpan data mahasiswa secara sementara selama aplikasi berjalan
        private static List<Mahasiswa> _listMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Aryoseto Wahyatma", Nim = "103022300114" },
            new Mahasiswa { Nama = "Lionel Messi", Nim = "10" },
            new Mahasiswa { Nama = "Cristiano Ronaldo", Nim = "7" }
        };

        // GET: /api/mahasiswa
        [HttpGet]
        public ActionResult<List<Mahasiswa>> GetAll()
        {
            Console.WriteLine("Jumlah mahasiswa: " + _listMahasiswa.Count);
            return _listMahasiswa;
        }

        // GET: /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= _listMahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan." });
            }

            return _listMahasiswa[index];
        }

        // POST: /api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            if (mahasiswa == null || string.IsNullOrEmpty(mahasiswa.Nama) || string.IsNullOrEmpty(mahasiswa.Nim))
            {
                return BadRequest(new { message = "Data mahasiswa tidak valid." });
            }

            _listMahasiswa.Add(mahasiswa);
            return Ok(new { message = "Mahasiswa berhasil ditambahkan." });
        }

        // DELETE: /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= _listMahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan." });
            }

            _listMahasiswa.RemoveAt(index);
            return Ok(new { message = "Mahasiswa berhasil dihapus." });
        }
    }
}
