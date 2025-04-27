namespace tpmodul10_103022300114
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        // Static list supaya data tetap tersimpan selama aplikasi jalan
        private static List<Mahasiswa> listMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Aryoseto Wahyatma", Nim = "103022300114" },
            new Mahasiswa { Nama = "Lionel Messi", Nim = "10" },
            new Mahasiswa { Nama = "Cristiano Ronaldo", Nim = "7" }
        };

        // GET /api/mahasiswa
        [HttpGet]
        public ActionResult<List<Mahasiswa>> GetAll()
        {
            Console.WriteLine("Jumlah mahasiswa: " + listMahasiswa.Count);
            return listMahasiswa;
        }

        // GET /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= listMahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan." });
            }
            return listMahasiswa[index];
        }

        // POST /api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mhs)
        {
            if (mhs == null || string.IsNullOrEmpty(mhs.Nama) || string.IsNullOrEmpty(mhs.Nim))
            {
                return BadRequest(new { message = "Data mahasiswa tidak valid." });
            }

            listMahasiswa.Add(mhs);
            return Ok(new { message = "Mahasiswa berhasil ditambahkan." });
        }

        // DELETE /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= listMahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan." });
            }

            listMahasiswa.RemoveAt(index);
            return Ok(new { message = "Mahasiswa berhasil dihapus." });
        }
    }
}
