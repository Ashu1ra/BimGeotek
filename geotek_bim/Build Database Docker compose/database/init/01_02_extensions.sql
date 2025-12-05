\c geotek_db;
-- Подключение расширений:
-- PostGIS — геометрия, GIST индексы, проекции, операции пересечения
CREATE EXTENSION IF NOT EXISTS postgis;
-- Topology и raster — для GIS-данных (tif, gml, DEM)
CREATE EXTENSION IF NOT EXISTS postgis_topology;
CREATE EXTENSION IF NOT EXISTS postgis_raster;
-- pgcrypto — шифрование, HMAC, hashing
CREATE EXTENSION IF NOT EXISTS pgcrypto;