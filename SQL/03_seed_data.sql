INSERT INTO dbo.Recipes (Title, PrepMinutes, CookMinutes, Servings)
VALUES
('Pasta', 10, 15, 2),
('Sallad', 10, 0, 1),
('Kycklinggryta', 15, 25, 4),
('Tacos', 20, 10, 4),
('Pannkakor', 10, 20, 3),
('Fisk i ugn', 10, 25, 2),
('Wok', 15, 10, 2),
('Lasagne', 20, 40, 6),
('Smoothie', 5, 0, 1),
('Omelett', 5, 5, 1);

INSERT INTO dbo.Ingredients (Name)
VALUES
('Salt'), ('Peppar'), ('Kyckling'), ('Tomat'), ('Pasta'), ('Ost');

-- Minst 25 rader här (exempel: koppla lite fritt)
INSERT INTO dbo.RecipeIngredients (RecipeId, IngredientId, Quantity, Unit)
VALUES
(1, 5, 200, 'g'), (1, 1, 1, 'tsk'), (1, 2, 1, 'krm'),
(2, 4, 1, 'st'), (2, 1, 1, 'krm'), (2, 2, 1, 'krm'),
(3, 3, 400, 'g'), (3, 4, 2, 'st'), (3, 1, 1, 'tsk'),
(4, 4, 2, 'st'), (4, 3, 300, 'g'), (4, 1, 1, 'tsk'),
(5, 6, 50, 'g'), (5, 1, 1, 'krm'), (5, 2, 1, 'krm'),
(6, 1, 1, 'tsk'), (6, 2, 1, 'krm'), (6, 4, 1, 'st'),
(7, 3, 250, 'g'), (7, 1, 1, 'krm'), (7, 2, 1, 'krm'),
(8, 6, 100, 'g'), (8, 5, 300, 'g'), (8, 4, 2, 'st'),
(9, 4, 1, 'st');
