PGDMP                 	    
    x            test    12.0    12.0                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    41234    test    DATABASE     �   CREATE DATABASE test WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Portuguese_Brazil.1252' LC_CTYPE = 'Portuguese_Brazil.1252';
    DROP DATABASE test;
                postgres    false            �            1259    41237    ponto    TABLE     �   CREATE TABLE public.ponto (
    "IdPonto" integer NOT NULL,
    "NomeFuncionario" text NOT NULL,
    "Data" timestamp without time zone NOT NULL,
    "Tipo" integer NOT NULL
);
    DROP TABLE public.ponto;
       public         heap    postgres    false            �            1259    41235    ponto_IdPonto_seq    SEQUENCE     �   CREATE SEQUENCE public."ponto_IdPonto_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."ponto_IdPonto_seq";
       public          postgres    false    203            	           0    0    ponto_IdPonto_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public."ponto_IdPonto_seq" OWNED BY public.ponto."IdPonto";
          public          postgres    false    202            �
           2604    41240    ponto IdPonto    DEFAULT     r   ALTER TABLE ONLY public.ponto ALTER COLUMN "IdPonto" SET DEFAULT nextval('public."ponto_IdPonto_seq"'::regclass);
 >   ALTER TABLE public.ponto ALTER COLUMN "IdPonto" DROP DEFAULT;
       public          postgres    false    203    202    203                      0    41237    ponto 
   TABLE DATA           M   COPY public.ponto ("IdPonto", "NomeFuncionario", "Data", "Tipo") FROM stdin;
    public          postgres    false    203   �
       
           0    0    ponto_IdPonto_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."ponto_IdPonto_seq"', 19, true);
          public          postgres    false    202            �
           2606    41245    ponto ponto_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.ponto
    ADD CONSTRAINT ponto_pkey PRIMARY KEY ("IdPonto");
 :   ALTER TABLE ONLY public.ponto DROP CONSTRAINT ponto_pkey;
       public            postgres    false    203                  x������ � �     