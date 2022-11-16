-- Database: cspharma_informacional

-- DROP DATABASE IF EXISTS cspharma_informacional;

CREATE DATABASE cspharma_informacional
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Spain.1252'
    LC_CTYPE = 'Spanish_Spain.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

COMMENT ON DATABASE cspharma_informacional
    IS 'Base de datos que gestiona en los que se almacenan los datos brutos de los pedidos realizados a la distribuidora farmaceutica CSPharma';


    -- SCHEMA: dwh_torrecontrol

-- DROP SCHEMA IF EXISTS dwh_torrecontrol ;

CREATE SCHEMA IF NOT EXISTS dwh_torrecontrol
    AUTHORIZATION postgres;

COMMENT ON SCHEMA dwh_torrecontrol
    IS 'Esquema que almacena la información obtenida de los datos brutos obtenidos del esquema dlk_informacional';

    -- Table: dwh_torrecontrol.tdc_cat_estados_devolucion_pedido

-- DROP TABLE IF EXISTS dwh_torrecontrol.tdc_cat_estados_devolucion_pedido;

CREATE TABLE IF NOT EXISTS dwh_torrecontrol.tdc_cat_estados_devolucion_pedido
(
    md_uuid character varying(300) COLLATE pg_catalog."default" NOT NULL,
    md_date timestamp without time zone NOT NULL,
    id bigint NOT NULL DEFAULT nextval('dwh_torrecontrol.tdc_cat_estados_devolucion_pedido_id_seq'::regclass),
    cod_estado_devolucion character varying(300) COLLATE pg_catalog."default" NOT NULL,
    des_estado_devolucion character varying(300) COLLATE pg_catalog."default",
    CONSTRAINT tdc_cat_estados_devolucion_pedido_pkey PRIMARY KEY (id),
    CONSTRAINT unique_cod_estado_devolucion UNIQUE (cod_estado_devolucion)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS dwh_torrecontrol.tdc_cat_estados_devolucion_pedido
    OWNER to postgres;

-- SEQUENCE: dwh_torrecontrol.tdc_cat_estados_devolucion_pedido_id_seq

-- DROP SEQUENCE IF EXISTS dwh_torrecontrol.tdc_cat_estados_devolucion_pedido_id_seq;

CREATE SEQUENCE IF NOT EXISTS dwh_torrecontrol.tdc_cat_estados_devolucion_pedido_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1
    OWNED BY tdc_cat_estados_devolucion_pedido.id;

ALTER SEQUENCE dwh_torrecontrol.tdc_cat_estados_devolucion_pedido_id_seq
    OWNER TO postgres;


-- Table: dwh_torrecontrol.tdc_cat_estados_envio_pedido

-- DROP TABLE IF EXISTS dwh_torrecontrol.tdc_cat_estados_envio_pedido;

CREATE TABLE IF NOT EXISTS dwh_torrecontrol.tdc_cat_estados_envio_pedido
(
    md_uuid character varying(300) COLLATE pg_catalog."default" NOT NULL,
    md_date timestamp without time zone NOT NULL,
    id bigint NOT NULL DEFAULT nextval('dwh_torrecontrol.tdc_cat_estados_envio_pedido_id_seq'::regclass),
    cod_estado_envio character varying(300) COLLATE pg_catalog."default" NOT NULL,
    des_estado_envio character varying(300) COLLATE pg_catalog."default",
    CONSTRAINT pk_tdc_cat_estados_envio_pedido PRIMARY KEY (id),
    CONSTRAINT unique_cod_estado_envio UNIQUE (cod_estado_envio)
        INCLUDE(cod_estado_envio)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS dwh_torrecontrol.tdc_cat_estados_envio_pedido
    OWNER to postgres;

-- SEQUENCE: dwh_torrecontrol.tdc_cat_estados_envio_pedido_id_seq

-- DROP SEQUENCE IF EXISTS dwh_torrecontrol.tdc_cat_estados_envio_pedido_id_seq;

CREATE SEQUENCE IF NOT EXISTS dwh_torrecontrol.tdc_cat_estados_envio_pedido_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1
    OWNED BY tdc_cat_estados_envio_pedido.id;

ALTER SEQUENCE dwh_torrecontrol.tdc_cat_estados_envio_pedido_id_seq
    OWNER TO postgres;

    -- Table: dwh_torrecontrol.tdc_cat_estados_pago_pedido

-- DROP TABLE IF EXISTS dwh_torrecontrol.tdc_cat_estados_pago_pedido;

CREATE TABLE IF NOT EXISTS dwh_torrecontrol.tdc_cat_estados_pago_pedido
(
    md_uuid character varying(300) COLLATE pg_catalog."default" NOT NULL,
    md_date timestamp without time zone NOT NULL,
    id bigint NOT NULL DEFAULT nextval('dwh_torrecontrol.tdc_cat_estados_pago_pedido_id_seq'::regclass),
    cod_estado_pago character varying(300) COLLATE pg_catalog."default" NOT NULL,
    des_estado_pago character varying COLLATE pg_catalog."default",
    CONSTRAINT tdc_cat_estados_pago_pedido_pkey PRIMARY KEY (id),
    CONSTRAINT unique_cod_estado_pago UNIQUE (cod_estado_pago)
        INCLUDE(cod_estado_pago)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS dwh_torrecontrol.tdc_cat_estados_pago_pedido
    OWNER to postgres;

-- SEQUENCE: dwh_torrecontrol.tdc_cat_estados_pago_pedido_id_seq

-- DROP SEQUENCE IF EXISTS dwh_torrecontrol.tdc_cat_estados_pago_pedido_id_seq;

CREATE SEQUENCE IF NOT EXISTS dwh_torrecontrol.tdc_cat_estados_pago_pedido_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1
    OWNED BY tdc_cat_estados_pago_pedido.id;

ALTER SEQUENCE dwh_torrecontrol.tdc_cat_estados_pago_pedido_id_seq
    OWNER TO postgres;

-- Table: dwh_torrecontrol.tdc_tch_estado_pedidos

-- DROP TABLE IF EXISTS dwh_torrecontrol.tdc_tch_estado_pedidos;

CREATE TABLE IF NOT EXISTS dwh_torrecontrol.tdc_tch_estado_pedidos
(
    md_uuid character varying(300) COLLATE pg_catalog."default" NOT NULL,
    md_date time without time zone NOT NULL,
    id bigint NOT NULL DEFAULT nextval('dwh_torrecontrol.tdc_tch_estado_pedidos_id_seq'::regclass),
    cod_estado_envio character varying(300) COLLATE pg_catalog."default",
    cod_estado_pago character varying(300) COLLATE pg_catalog."default",
    cod_estado_devolucion character varying(300) COLLATE pg_catalog."default",
    cod_pedido character varying(300) COLLATE pg_catalog."default" NOT NULL,
    cod_linea character varying(300) COLLATE pg_catalog."default" NOT NULL,
    cod_provincia character varying(300) COLLATE pg_catalog."default" NOT NULL,
    cod_municipio character varying(300) COLLATE pg_catalog."default" NOT NULL,
    cod_barrio character varying(300) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT pk_tdc_tch_estado_pedidos PRIMARY KEY (id),
    CONSTRAINT "fk_estadoDevolucion_estadoPedidos" FOREIGN KEY (cod_estado_devolucion)
        REFERENCES dwh_torrecontrol.tdc_cat_estados_devolucion_pedido (cod_estado_devolucion) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "fk_estadoEnvio_estadoPedidos" FOREIGN KEY (cod_estado_envio)
        REFERENCES dwh_torrecontrol.tdc_cat_estados_envio_pedido (cod_estado_envio) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "fk_estadoPago_estadoPedidos" FOREIGN KEY (cod_estado_pago)
        REFERENCES dwh_torrecontrol.tdc_cat_estados_pago_pedido (cod_estado_pago) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS dwh_torrecontrol.tdc_tch_estado_pedidos
    OWNER to postgres;

    -- SEQUENCE: dwh_torrecontrol.tdc_tch_estado_pedidos_id_seq

-- DROP SEQUENCE IF EXISTS dwh_torrecontrol.tdc_tch_estado_pedidos_id_seq;

CREATE SEQUENCE IF NOT EXISTS dwh_torrecontrol.tdc_tch_estado_pedidos_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1
    OWNED BY tdc_tch_estado_pedidos.id;

ALTER SEQUENCE dwh_torrecontrol.tdc_tch_estado_pedidos_id_seq
    OWNER TO postgres;                    