INSERT INTO CATEGORIE_RECETTE (CTG_NOM_CATEGORIE_RECETTE) VALUES ('Entree');
INSERT INTO CATEGORIE_RECETTE (CTG_NOM_CATEGORIE_RECETTE) VALUES ('Plat');
INSERT INTO CATEGORIE_RECETTE (CTG_NOM_CATEGORIE_RECETTE) VALUES ('Dessert');

DELETE FROM CATEGORIE_RECETTE WHERE CTG_ID = 6 ;

SELECT * FROM CATEGORIE_RECETTE;


ALTER TABLE RECETTE
DROP COLUMN R_TPSPREP_RECETTE;
ALTER TABLE RECETTE
DROP COLUMN R_TPSCUISSON_RECETTE;
ALTER TABLE RECETTE
DROP COLUMN R_TPSREPOS_RECETTE;
 
ALTER TABLE RECETTE
ADD  R_TPSPREP_RECETTE float;
ALTER TABLE RECETTE
ADD  R_TPSCUISSON_RECETTE float;
ALTER TABLE RECETTE
ADD  R_TPSREPOS_RECETTE float;

ALTER TABLE RECETTE
DROP COLUMN R_INGREDIENTS_RECETTE;

ALTER TABLE RECETTE
ADD  R_INGREDIENTS_RECETTE varChar(500);

INSERT INTO RECETTE (CTG_ID,R_NOM_RECETTE,R_DESC_RECETTE,R_TPSPREP_RECETTE, R_TPSCUISSON_RECETTE, R_TPSREPOS_RECETTE, R_INGREDIENTS_RECETTE, R_NBR_PERS_RECETTE)VALUES (1,'Feuillet� au crabe','Pr�chauffer le four � 230� (th 7-8) M�langer la chair de crabe, le jus de citron, la chapelure, les herbes et le piment Lier le tout avec un �uf Saler et poivrer D�couper 4 disques dans la p�te feuillet�e et r�partir la farce sur la moiti� de chaque disque, en laissant 1 cm de rebord Rabattre l autre moiti� et souder Badigeonner les feuillet�s avec un oeuf battu et sal�, puis strier avec une fourchette Mettre au four � 180� (th 6) pendant 20mn minimum', 10, 20, 0,'300g de p�te feuillet�e 2 �ufs Sel et poivre 3 ou 4 c � s de cr�me fraiche 2 cuill�res � soupe de chapelure 2 petits oignons ou �chalotes 120g de chair de crabe Le jus d un citron 3 cuill�res � soupe de persil hach� 1 pointe de couteau de piment de cayenne', 4 );

SELECT * FROM RECETTE;