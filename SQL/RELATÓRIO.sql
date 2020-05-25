USE ControleCondominal

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
				ISNULL(SUM(M.QtdPets), 0) 
			FROM 
				Moradors as M 
			INNER JOIN 
				Familias as F ON F.Id = M.FamiliaId 
			INNER JOIN
				Condominios as C ON C.Id = F.CondominioId AND C.Id = @CondId))

	SET @CondID = @CondID + 1 
END

SELECT * FROM @Conds ORDER BY Bairro