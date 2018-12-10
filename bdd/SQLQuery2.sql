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

INSERT INTO RECETTE (CTG_ID,R_NOM_RECETTE,R_DESC_RECETTE,R_TPSPREP_RECETTE, R_TPSCUISSON_RECETTE, R_TPSREPOS_RECETTE, R_INGREDIENTS_RECETTE, R_NBR_PERS_RECETTE)VALUES (1,'Feuilleté au crabe','Préchauffer le four à 230° (th 7-8) Mélanger la chair de crabe, le jus de citron, la chapelure, les herbes et le piment Lier le tout avec un œuf Saler et poivrer Découper 4 disques dans la pâte feuilletée et répartir la farce sur la moitié de chaque disque, en laissant 1 cm de rebord Rabattre l autre moitié et souder Badigeonner les feuilletés avec un oeuf battu et salé, puis strier avec une fourchette Mettre au four à 180° (th 6) pendant 20mn minimum', 10, 20, 0,'300g de pâte feuilletée 2 œufs Sel et poivre 3 ou 4 c à s de crème fraiche 2 cuillères à soupe de chapelure 2 petits oignons ou échalotes 120g de chair de crabe Le jus d un citron 3 cuillères à soupe de persil haché 1 pointe de couteau de piment de cayenne', 4 );

SELECT * FROM RECETTE;