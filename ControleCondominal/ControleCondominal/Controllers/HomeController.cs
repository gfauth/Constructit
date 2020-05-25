using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleCondominal.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleCondominal.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Relatorio()
        {
            var result = _context.Database.ExecuteSqlCommand(@"
                        TRUNCATE TABLE Relatorios;
                        DECLARE @CondID INT = 1;
                        DECLARE @RowCnt BIGINT = 0;

                        SELECT @RowCnt = COUNT(0) FROM Condominios;
 
                        WHILE @CondID <= @RowCnt
                        BEGIN   
                            INSERT INTO 
		                        Relatorios (Bairro, QtdPets) 
		                        VALUES(
			                        (SELECT 
				                        Bairro 
			                        FROM 
				                        Condominios 
			                        WHERE Id = @CondId), 
			                        (SELECT 
				                        ISNULL(SUM(M.QtdPets), 0) 
			                        FROM 
				                        Moradors as M 
			                        INNER JOIN 
				                        Familias as F ON F.Id = M.FamiliaId 
			                        INNER JOIN
				                        Condominios as C ON C.Id = F.CondominioId AND C.Id = @CondId))

	                        SET @CondID = @CondID + 1 
                        END");
            var relatorio = _context.Relatorios.OrderBy(c => c.Bairro).ToList();
            return View(relatorio);
        }
    }
}
