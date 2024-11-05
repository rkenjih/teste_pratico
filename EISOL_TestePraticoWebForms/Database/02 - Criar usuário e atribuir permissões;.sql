/*
 * Primeiro crie um schema chamado DEV
 * Para criar o novo usuário, você deve estar logado com SYS ou SYSTEM.
 * No teste que fiz, funcionou com DBAODB
 **/

-- Usuário: NOVO_PROGRAMADOR
-- Senha: hN2Q1afmHoaM_#
-- Schema: DEV
-- Senha usuário schema: hN2Q1@afm+H#,oaM

CREATE USER NOVO_PROGRAMADOR IDENTIFIED BY hN2Q1afmHoaM_#;

GRANT CONNECT TO NOVO_PROGRAMADOR;

-- Esse usuário tem limitações para apenas cirar alguns objetos importantes e nada além do necesário.
BEGIN
   FOR obj IN (SELECT object_name, object_type 
               FROM all_objects 
               WHERE owner = 'DEV' 
                 AND object_type IN ('TABLE', 'VIEW', 'SEQUENCE', 'PROCEDURE', 'FUNCTION'))
   LOOP
      EXECUTE IMMEDIATE 'GRANT ALL ON DEV.' || obj.object_name || ' TO NOVO_PROGRAMADOR';
   END LOOP;
END;

