IF NOT EXISTS (
    SELECT
        *
    FROM
        sys.databases
    WHERE
        name = 'WarehouseAPIDatabase'
) BEGIN CREATE DATABASE [WarehouseAPIDatabase]
END
GO