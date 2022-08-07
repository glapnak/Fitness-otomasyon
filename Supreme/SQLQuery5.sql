select convert(varchar, getutcdate(), 23)
SELECT giris,cikis,sureci,

CASE

       WHEN DATEDIFF(DAY, getutcdate(), giris) <= 0
        THEN 'Pasif'
        ELSE 'Aktif'
    END cikis
FROM 
    Gym
WHERE 
    giris IS NOT NULL
ORDER BY 
    getutcdate();

        UPDATE Gym
        SET cikis = 'Aktif'
        where DATEDIFF(DAY, getutcdate(), giris) >= 0

        UPDATE Gym
        SET cikis = 'Pasif'
        where DATEDIFF(DAY, getutcdate(), giris) <= 0

        UPDATE Gym
        SET sureci = DATEDIFF(DAY, getutcdate(), giris)

