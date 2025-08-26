-- Criar o schema se não existir
CREATE DATABASE IF NOT EXISTS `race_stats`
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE `race_stats`;

-- Criar tabela de times
CREATE TABLE IF NOT EXISTS teams (
  Id CHAR(36) PRIMARY KEY,
  Name VARCHAR(100) NOT NULL,
  Country VARCHAR(50) NOT NULL,
  Founded DATE NOT NULL,
  ColorHex VARCHAR(10) NOT NULL
);

-- Criar tabela de pilotos
CREATE TABLE IF NOT EXISTS pilots (
  Id CHAR(36) PRIMARY KEY,
  Name VARCHAR(100) NOT NULL,
  Fastestlap TIME,
  Weight DECIMAL(5, 2),
  Gender INT,
  Nationality VARCHAR(50) NOT NULL,
  Circuit VARCHAR(100) NOT NULL,
  TeamId CHAR(36) NOT NULL,
  Category INT,
  Leader INT,
  FOREIGN KEY (TeamId) REFERENCES teams(Id)
);

-- Inserir times (semente inicial)
INSERT INTO teams (Id, Name, Country, Founded, ColorHex) VALUES
('1d7e5c92-8a4b-4c61-9f1d-2a8f7c9b1e3f', 'Carlin', 'UK', '2025-01-01', '#0033A0'),
('2d3f4a5b-6c7d-4e8f-9a1b-3c5d7e9f2a4b', 'Chip Ganassi Racing', 'USA', '2025-01-01', '#001489'),
('2e9f3d84-5c1a-4b7e-9f8a-1c2d5e6f7a8b', 'Hitech Grand Prix', 'UK', '2025-01-01', '#A0A0A0'),
('2f1c9a1e-9f1d-4d5a-89b2-1d3b2a7e8c4a', 'Ferrari', 'Italy', '2025-01-01', '#DC0000'),
('3b4c5d6e-7f8a-9b0c-1d2e-3f4a5b6c7d8e', 'Team Mugen', 'Japan', '2025-01-01', '#FF0000'),
('3f5c9d91-7f2b-46de-a59a-efc82392bbf6', 'McLaren', 'UK', '2025-01-01', '#FF8700'),
('4e7b2a63-8d42-43fb-9ab2-8f9f43b51c99', 'Williams', 'UK', '2025-01-01', '#005AFF'),
('4f8b2e7c-9a1d-4c3f-8e6b-2d7c5a9f1e3b', 'Van Amersfoort Racing', 'Netherlands', '2025-01-01', '#FF6600'),
('5c1f9a7d-4e2b-4d6f-9a13-7c5d9b8f6e1a', 'ART Grand Prix', 'France', '2025-01-01', '#000000'),
('5d3a7b9e-1f6c-4e9d-8b2a-7c3f6e1d9a2b', 'US Racing', 'Germany', '2025-01-01', '#FF0000'),
('5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b', 'Jaguar TCS Racing', 'UK', '2025-01-01', '#006341'),
('6b7f3e5a-1f43-4f27-9a68-8c1e24a0f37d', 'Mercedes', 'Germany', '2025-01-01', '#00D2BE'),
('6c7a8d9e-1b2f-4c3d-8a9e-5f6b7d8e9c1a', 'Team Penske', 'USA', '2025-01-01', '#FF0000'),
('6e7f8a9b-0c1d-2e3f-4a5b-6c7d8e9f0a1b', 'KIC Motorsport', 'Finland', '2025-01-01', '#003399'),
('7a2e1c94-3b5d-4d7f-8c1a-9f2b4c6d8e7f', 'Trident', 'Italy', '2025-01-01', '#005BAC'),
('7c6d5e4f-3a2b-1c0d-9e8f-7a6b5c4d3e2f', 'Jenzer Motorsport', 'Switzerland', '2025-01-01', '#0000FF'),
('8a4e7d22-2f8e-42d1-bcf4-72d91f08c8c1', 'Red Bull Racing', 'Austria', '2025-01-01', '#1E41FF'),
('8d9e0f1a-2b3c-4d5e-6f7a-8b9c0d1e2f3a', 'DS Penske', 'France', '2025-01-01', '#FFD700'),
('9b8a2c7e-7c6d-4f42-b1f3-2c7a3c9f8e2d', 'Prema Racing', 'Italy', '2025-01-01', '#FF0000'),
('9f1a2b3c-4d5e-6f7a-8b9c-0d1e2f3a4b5c', 'Campos Racing', 'Spain', '2025-01-01', '#FFD700');

INSERT INTO pilots (Id, Name, Fastestlap, Weight, Gender, Nationality, Circuit, TeamId, Category, Leader) VALUES
('550e8400-e29b-41d4-a716-446655440000', 'Lewis Hamilton', '00:01:23.456', 78.500000000000000000000000000000, 0, 'UK', 'Silverstone', '6b7f3e5a-1f43-4f27-9a68-8c1e24a0f37d', 0, 1),
('550e8400-e29b-41d4-a716-446655440001', 'Valtteri Bottas', '00:01:24.789', 72.300000000000000000000000000000, 0, 'Finland', 'Monza', '6e7f8a9b-0c1d-2e3f-4a5b-6c7d8e9f0a1b', 0, 0),
('550e8400-e29b-41d4-a716-446655440002', 'Charles Leclerc', '00:01:22.345', 75.200000000000000000000000000000, 0, 'Monaco', 'Monaco', '2f1c9a1e-9f1d-4d5a-89b2-1d3b2a7e8c4a', 0, 0),
('550e8400-e29b-41d4-a716-446655440003', 'Max Verstappen', '00:01:21.890', 80.100000000000000000000000000000, 0, 'Netherlands', 'Spa', '8a4e7d22-2f8e-42d1-bcf4-72d91f08c8c1', 0, 1),
('550e8400-e29b-41d4-a716-446655440004', 'Sergio Perez', '00:01:23.123', 68.900000000000000000000000000000, 0, 'Mexico', 'Mexico City', '8a4e7d22-2f8e-42d1-bcf4-72d91f08c8c1', 0, 0),
('550e8400-e29b-41d4-a716-446655440005', 'Lando Norris', '00:01:24.567', 70.800000000000000000000000000000, 0, 'UK', 'Silverstone', '3f5c9d91-7f2b-46de-a59a-efc82392bbf6', 0, 0),
('550e8400-e29b-41d4-a716-446655440006', 'Oscar Piastri', '00:01:22.901', 65.700000000000000000000000000000, 0, 'Australia', 'Melbourne', '3f5c9d91-7f2b-46de-a59a-efc82392bbf6', 0, 0),
('550e8400-e29b-41d4-a716-446655440007', 'George Russell', '00:01:23.678', 73.400000000000000000000000000000, 0, 'UK', 'Silverstone', '6b7f3e5a-1f43-4f27-9a68-8c1e24a0f37d', 0, 0),
('550e8400-e29b-41d4-a716-446655440008', 'Alex Albon', '00:01:24.234', 67.600000000000000000000000000000, 0, 'Thailand', 'Sepang', '4e7b2a63-8d42-43fb-9ab2-8f9f43b51c99', 0, 0),
('550e8400-e29b-41d4-a716-446655440009', 'Jamie Chadwick', '00:01:25.123', 58.900000000000000000000000000000, 1, 'UK', 'Brands Hatch', '1d7e5c92-8a4b-4c61-9f1d-2a8f7c9b1e3f', 2, 0),
('550e8400-e29b-41d4-a716-44665544000a', 'Sebastian Vettel', '00:01:22.456', 74.300000000000000000000000000000, 0, 'Germany', 'Hockenheim', '6b7f3e5a-1f43-4f27-9a68-8c1e24a0f37d', 1, 0),
('550e8400-e29b-41d4-a716-44665544000b', 'Fernando Alonso', '00:01:23.789', 69.500000000000000000000000000000, 0, 'Spain', 'Catalunya', '2f1c9a1e-9f1d-4d5a-89b2-1d3b2a7e8c4a', 1, 0),
('550e8400-e29b-41d4-a716-44665544000c', 'Pierre Gasly', '00:01:24.890', 71.200000000000000000000000000000, 0, 'France', 'Paul Ricard', '5c1f9a7d-4e2b-4d6f-9a13-7c5d9b8f6e1a', 1, 0),
('550e8400-e29b-41d4-a716-44665544000d', 'Esteban Ocon', '00:01:23.345', 66.800000000000000000000000000000, 0, 'France', 'Monaco', '5c1f9a7d-4e2b-4d6f-9a13-7c5d9b8f6e1a', 1, 0),
('550e8400-e29b-41d4-a716-44665544000e', 'Yuki Tsunoda', '00:01:24.678', 63.900000000000000000000000000000, 0, 'Japan', 'Suzuka', '3b4c5d6e-7f8a-9b0c-1d2e-3f4a5b6c7d8e', 1, 0),
('550e8400-e29b-41d4-a716-44665544000f', 'Mick Schumacher', '00:01:25.234', 72.100000000000000000000000000000, 0, 'Germany', 'Nurburgring', '8d9e0f1a-2b3c-4d5e-6f7a-8b9c0d1e2f3a', 2, 0),
('550e8400-e29b-41d4-a716-446655440010', 'Logan Sargeant', '00:01:23.901', 68.700000000000000000000000000000, 0, 'USA', 'Miami', '4e7b2a63-8d42-43fb-9ab2-8f9f43b51c99', 2, 0),
('550e8400-e29b-41d4-a716-446655440011', 'Zhou Guanyu', '00:01:24.567', 64.500000000000000000000000000000, 0, 'China', 'Shanghai', '3f5c9d91-7f2b-46de-a59a-efc82392bbf6', 2, 0),
('550e8400-e29b-41d4-a716-446655440012', 'Kevin Magnussen', '00:01:23.123', 70.300000000000000000000000000000, 0, 'Denmark', 'Copenhagen', '6c7a8d9e-1b2f-4c3d-8a9e-5f6b7d8e9c1a', 2, 0),
('550e8400-e29b-41d4-a716-446655440013', 'Nico Hulkenberg', '00:01:24.890', 75.600000000000000000000000000000, 0, 'Germany', 'Hockenheim', '6c7a8d9e-1b2f-4c3d-8a9e-5f6b7d8e9c1a', 2, 0),
('550e8400-e29b-41d4-a716-446655440014', 'Daniel Ricciardo', '00:01:22.789', 71.900000000000000000000000000000, 0, 'Australia', 'Melbourne', '8a4e7d22-2f8e-42d1-bcf4-72d91f08c8c1', 2, 0),
('550e8400-e29b-41d4-a716-446655440015', 'Tatiana Calderon', '00:01:25.345', 55.800000000000000000000000000000, 1, 'Colombia', 'Bogota', '9f1a2b3c-4d5e-6f7a-8b9c-0d1e2f3a4b5c', 3, 0),
('550e8400-e29b-41d4-a716-446655440016', 'Alexander Peroni', '00:01:23.456', 67.200000000000000000000000000000, 0, 'Australia', 'Adelaide', '2e9f3d84-5c1a-4b7e-9f8a-1c2d5e6f7a8b', 3, 0),
('550e8400-e29b-41d4-a716-446655440017', 'Sophia Floersch', '00:01:24.123', 52.300000000000000000000000000000, 1, 'Germany', 'Nurburgring', '7c6d5e4f-3a2b-1c0d-9e8f-7a6b5c4d3e2f', 3, 0),
('550e8400-e29b-41d4-a716-446655440018', 'Jehan Daruvala', '00:01:23.678', 66.400000000000000000000000000000, 0, 'India', 'Delhi', '9b8a2c7e-7c6d-4f42-b1f3-2c7a3c9f8e2d', 3, 0),
('550e8400-e29b-41d4-a716-446655440019', 'Marcus Armstrong', '00:01:24.901', 69.100000000000000000000000000000, 0, 'New Zealand', 'Auckland', '2d3f4a5b-6c7d-4e8f-9a1b-3c5d7e9f2a4b', 4, 0),
('550e8400-e29b-41d4-a716-44665544001a', 'Scott McLaughlin', '00:01:22.345', 74.700000000000000000000000000000, 0, 'New Zealand', 'Indianapolis', '6c7a8d9e-1b2f-4c3d-8a9e-5f6b7d8e9c1a', 4, 0),
('550e8400-e29b-41d4-a716-44665544001b', 'Josef Newgarden', '00:01:23.234', 70.500000000000000000000000000000, 0, 'USA', 'St. Petersburg', '6c7a8d9e-1b2f-4c3d-8a9e-5f6b7d8e9c1a', 4, 1),
('550e8400-e29b-41d4-a716-44665544001c', 'Pato O''Ward', '00:01:24.567', 68.300000000000000000000000000000, 0, 'Mexico', 'Mexico City', '2d3f4a5b-6c7d-4e8f-9a1b-3c5d7e9f2a4b', 4, 0),
('550e8400-e29b-41d4-a716-44665544001d', 'Simona de Silvestro', '00:01:25.789', 57.900000000000000000000000000000, 1, 'Switzerland', 'Zurich', '7c6d5e4f-3a2b-1c0d-9e8f-7a6b5c4d3e2f', 4, 0),
('550e8400-e29b-41d4-a716-44665544001e', 'Stoffel Vandoorne', '00:01:23.901', 71.600000000000000000000000000000, 0, 'Belgium', 'Spa', '5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b', 7, 0),
('550e8400-e29b-41d4-a716-44665544001f', 'Nyck de Vries', '00:01:24.123', 67.800000000000000000000000000000, 0, 'Netherlands', 'Zandvoort', '5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b', 7, 0),
('550e8400-e29b-41d4-a716-446655440020', 'Sam Bird', '00:01:23.456', 70.200000000000000000000000000000, 0, 'UK', 'London', '5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b', 7, 0),
('550e8400-e29b-41d4-a716-446655440021', 'Edoardo Mortara', '00:01:24.789', 72.400000000000000000000000000000, 0, 'Switzerland', 'Zurich', '8d9e0f1a-2b3c-4d5e-6f7a-8b9c0d1e2f3a', 7, 0),
('550e8400-e29b-41d4-a716-446655440022', 'Norman Nato', '00:01:23.678', 68.900000000000000000000000000000, 0, 'France', 'Paris', '5c1f9a7d-4e2b-4d6f-9a13-7c5d9b8f6e1a', 7, 0),
('550e8400-e29b-41d4-a716-446655440023', 'Tomoki Nojiri', '00:01:22.901', 65.700000000000000000000000000000, 0, 'Japan', 'Suzuka', '3b4c5d6e-7f8a-9b0c-1d2e-3f4a5b6c7d8e', 8, 1),
('550e8400-e29b-41d4-a716-446655440024', 'Naoki Yamamoto', '00:01:23.123', 70.100000000000000000000000000000, 0, 'Japan', 'Fuji', '3b4c5d6e-7f8a-9b0c-1d2e-3f4a5b6c7d8e', 8, 0),
('550e8400-e29b-41d4-a716-446655440025', 'Hiroki Otsu', '00:01:24.345', 66.800000000000000000000000000000, 0, 'Japan', 'Motegi', '3b4c5d6e-7f8a-9b0c-1d2e-3f4a5b6c7d8e', 8, 0),
('550e8400-e29b-41d4-a716-446655440026', 'Ayumu Iwasa', '00:01:23.567', 64.300000000000000000000000000000, 0, 'Japan', 'Okayama', '2e9f3d84-5c1a-4b7e-9f8a-1c2d5e6f7a8b', 9, 0),
('550e8400-e29b-41d4-a716-446655440027', 'Lorenzo Colombo', '00:01:24.789', 68.500000000000000000000000000000, 0, 'Italy', 'Monza', '9b8a2c7e-7c6d-4f42-b1f3-2c7a3c9f8e2d', 9, 0),
('550e8400-e29b-41d4-a716-446655440028', 'Emilia Fittipaldi', '00:01:25.123', 54.700000000000000000000000000000, 1, 'Brazil', 'Interlagos', '2f1c9a1e-9f1d-4d5a-89b2-1d3b2a7e8c4a', 9, 0),
('550e8400-e29b-41d4-a716-446655440029', 'Dennis Hauger', '00:01:23.901', 67.900000000000000000000000000000, 0, 'Norway', 'Oslo', '7a2e1c94-3b5d-4d7f-8c1a-9f2b4c6d8e7f', 9, 0),
('550e8400-e29b-41d4-a716-44665544002a', 'Arthur Leclerc', '00:01:24.234', 65.400000000000000000000000000000, 0, 'Monaco', 'Monaco', '2f1c9a1e-9f1d-4d5a-89b2-1d3b2a7e8c4a', 6, 0),
('550e8400-e29b-41d4-a716-44665544002b', 'Jake Hughes', '00:01:23.456', 70.600000000000000000000000000000, 0, 'UK', 'Silverstone', '5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b', 6, 0),
('550e8400-e29b-41d4-a716-44665544002c', 'Marino Sato', '00:01:24.678', 64.800000000000000000000000000000, 0, 'Japan', 'Suzuka', '3b4c5d6e-7f8a-9b0c-1d2e-3f4a5b6c7d8e', 6, 0),
('550e8400-e29b-41d4-a716-44665544002d', 'David Schumacher', '00:01:23.890', 69.300000000000000000000000000000, 0, 'Germany', 'Hockenheim', '7c6d5e4f-3a2b-1c0d-9e8f-7a6b5c4d3e2f', 6, 0),
('550e8400-e29b-41d4-a716-44665544002e', 'Roman Stanek', '00:01:24.123', 66.100000000000000000000000000000, 0, 'Czech Republic', 'Brno', '7a2e1c94-3b5d-4d7f-8c1a-9f2b4c6d8e7f', 6, 0),
('550e8400-e29b-41d4-a716-44665544002f', 'Oliver Bearman', '00:01:23.345', 70.900000000000000000000000000000, 0, 'UK', 'Silverstone', '2f1c9a1e-9f1d-4d5a-89b2-1d3b2a7e8c4a', 5, 0),
('550e8400-e29b-41d4-a716-446655440030', 'Felipe Drugovich', '00:01:24.567', 68.700000000000000000000000000000, 0, 'Brazil', 'Interlagos', '9b8a2c7e-7c6d-4f42-b1f3-2c7a3c9f8e2d', 5, 0);
