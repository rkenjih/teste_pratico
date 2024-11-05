-- 1. Crie o usuário "DEV"
CREATE USER DEV IDENTIFIED BY hN2Q1afmHoaM_#; -- Senha = hN2Q1afmHoaM_#

-- 2. Conceda os privilégios necessários ao usuário DEV
GRANT CONNECT, RESOURCE TO DEV;

-- 3. (Opcional) Conceda permissões adicionais, como para criar views, sequências e sinônimos
GRANT CREATE VIEW, CREATE SEQUENCE, CREATE SYNONYM TO DEV;