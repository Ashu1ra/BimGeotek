\c geotek_db;
-- Настройки БД:
-- Универсальная сортировка для русского+английского
ALTER DATABASE geotek_db SET client_encoding = 'UTF8';
-- JSONB по умолчанию вместо JSON
ALTER DATABASE geotek_db SET default_toast_compression = 'lz4';
-- Храним временные данные с таймзоной
ALTER DATABASE geotek_db SET timezone = 'UTC';
-- Ускорение работы GIST/GIN индексов
ALTER DATABASE geotek_db SET enable_seqscan = OFF;