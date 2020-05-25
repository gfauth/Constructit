using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleCondominal.Migrations
{
    public partial class PROCATERelatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[Relatorio]
                AS
                BEGIN
                    DECLARE @CondID INT = 1;
                    DECLARE @RowCnt BIGINT = 0;
                    DECLARE @Conds TABLE (Bairro varchar(max), QtdPets int)

                    SELECT @RowCnt = COUNT(0) FROM Condominios;
 
                    WHILE @CondID <= @RowCnt
                    BEGIN   
                        INSERT INTO 
		                    @Conds (Bairro, QtdPets) 
		                    VALUES(
			                    (SELECT 
				                    Bairro 
			                    FROM 
				                    Condominios 
			                    WHERE Id = @CondId), 
			                    (SELECT 
				                    SUM(M.QtdPets) 
			                    FROM 
				                    Moradors as M 
			                    INNER JOIN 
				                    Familias as F ON F.Id = M.FamiliaId 
			                    INNER JOIN
				                    Condominios as C ON C.Id = F.CondominioId))

	                    SET @CondID = @CondID + 1 
                    END

                    SELECT Bairro, ISNULL(QtdPets, 0) as 'Bichos de Estimação' FROM @Conds ORDER BY Bairro
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
