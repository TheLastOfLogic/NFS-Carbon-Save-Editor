using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EA_MD5_hasher.Read_Data_Table;
using static EA_MD5_hasher.Save_Game_Structure;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.LinkLabel;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EA_MD5_hasher
{
    public static class Read_Data_Table
    {
        public static string New_Player_Name = "1551";
        public struct UnlockTable
        {
            public string LabelHash;      // e.g., 3391526480
            public string ArrayCount;     // e.g., 879
            public string Unknown1;       // e.g., 544
            public string Unknown2;       // e.g., 51
            public string Unknown3;       // e.g., 46
            public Unlocks[] Entries;
        }
        public struct Unlocks
        {
            public string Unlock_ID;
            public string Old_New;
        }

        public static string[] Stock_Cars = new string[]
        {
    "240sx",
    "300c",
    "350z",
    "997tt",
    "brera",
    "camaro",
    "carreragt",
    "caymans",
    "challenger71",
    "challengern",
    "charger06",
    "charger69",
    "clio",
    "clk500",
    "corvettez06",
    "cuda",
    "db9",
    "eclipsegt",
    "elise",
    "fordgt",
    "g35",
    "gallardo",
    "imprezawrxsti",
    "jaguarxk",
    "lancerevo9",
    "mazdaspeed3",
    "monaro",
    "murcielago",
    "mustanggt",
    "mustangshlbyo",
    "r32",
    "rx7",
    "rx8",
    "skyline",
    "sl65",
    "slr",
    "supra",
    "viper"
        };

        public static string[] Bonus_Cars = new string[]
            {
    "CE_240SX",
    "CE_350Z",
    "CE_CARRERA_GT",
    "CE_CHALLENGER",
    "CE_CHARGER",
    "CE_GT500",
    "CE_IMPREZA",
    "CE_MURCIELAGO",
    "CE_SKYLINE",
    "CE_SL65",
    "CROSS",
    "CS_GALLARDO",
    "CS_MUSTANGGT",
    "CS_RX8",
    "REVVED"
            };

        public static string[] Custom_Cars = new string[]
        {
    "997gt3rs",
    "bmwm3gtre46",
    "camaron",
    "ccx",
    "chevelle",
    "player_cop",
    "player_cop_corvette",
    "player_cop_gto",
    "player_cop_suv",
    "corolla",
    "player_dumptruck",
    "eclipse",
    "europa",
    "player_firetruck",
    "gto",
    "is300",
    "mr2",
    "murcielago640",
    "mustangshlbyn",
    "r8",
    "roadrunner",
    "zonda"
        };


        public static string[] Beta_Cars = new string[]
        {
            "copter",
            "911turbo"
        };

        public static string[] exoticCarNames = new string[]
{
    "911turbo",
    "997gt3rs",
    "997tt",
    "bmwm3gtre46",
    "bmwm3gtre46_crosschase",
    "m3gtrcareerstart",
    "brera",
    "t1_exotic_neville",
    "carreragt",
    "carrera_gmp7",
    "temp_exotic_03",
    "caymans",
    "colin",
    "ccx",
    "clk500",
    "copter",
    "db9",
    "wolf",
    "elise",
    "europa",
    "fordgt",
    "nikki",
    "gallardo",
    "demo_vid_gallardo",
    "jaguarxk",
    "footman",
    "murcielago",
    "murcielago640",
    "wolf_casino",
    "r8",
    "darius",
    "darius_ai",
    "sl65",
    "slr",
    "zonda"
};

        public static string[] muscleCarNames = new string[]
{
    "300c",
    "t1_muscle_neville",
    "camaro",
    "camaron",
    "challenger71",
    "player_cop_suv",
    "challengem",
    "angie_casino",
    "angie_casinoai",
    "charger06",
    "charger69",
    "angie",
    "samson",
    "temp_muscle_02",
    "chevelle",
    "corvettez06",
    "cross",
    "player_cop_corvette",
    "player_firetruck",
    "cuda",
    "temp_muscle_01",
    "gto",
    "player_cop_gto",
    "monaro",
    "mustanggt",
    "mustangshlbyn",
    "mustangshlbyo",
    "roadrunner",
    "viper",
    "player_dumptruck"
};

        public static string[] tunerCarNames = new string[]
{
    "240sx",
    "350z",
    "clio",
    "corolla",
    "eclipsegt",
    "eclipse",
    "yumi",
    "g35",
    "imprezawrxsti",
    "wrx_red",
    "is300",
    "lancerevo9",
    "kenji_casino",
    "mazdaspeed3",
    "t1_tuner_neville",
    "mr2",
    "r32",
    "rx7",
    "kenji",
    "rival_kenji",
    "rx8",
    "skyline",
    "player_cop",
    "supra",
    "hero"
};

        

        public static string[] trafficNames = new string[]
{
    // Tractors/Semi
    "semi",
    "cs_semi",
    "semia",
    "semib",
    "semibox",
    "semicmt",
    "semicon",
    "semicrate",
    "semilog",

    // Traffic/Street
    "traf4dseda",
    "traf4dsedb",
    "traf4dsedc",
    "trafcourt",
    "trafficcoup",
    "trafha",
    "trafstwag",
    "traftaxi",

    // Traffic/Truck
    "trafamb",
    "trafcemtr",
    "trafdmptr",
    "traffire",
    "trafgarb",

    // Traffic/Van
    "trafcamper",
    "trafminivan",
    "trafnews",
    "trafpickupa",
    "trafsuva",
    "trafvanb",

    // Trailers
    "trailera",
    "trailerb",
    "trailerbox",
    "trailercmt",
    "trailercon",
    "trailercrate",
    "trailerlog"
};


        public static string[] copNames = new string[]
{
    "copgto",
    "copmidsize",
    "copsport",
    "copsuv",
    "copgtoghost",
    "copghost",
    "copmidsize_ce",
    "copmidsize_nis",
    "copmidsize_nis_ld",
    "copmidsize_weak",
    "copcross",
    "copsportghost",
    "copsporthench",
    "copsuvl",
    "copsuvpatrol",
    // Choppers
    "copheli"
};

        public static string[] carUnlocks = new string[]
{
    "db9",
    "camaro",
    "300c",
    "skyline",
    "lancerevo9",
    "supra",
    "imprezawrxsti",
    "350z",
    "rx7",
    "clio",
    "r32",
    "eclipsegt",
    "mazdaspeed3",
    "rx8",
    "corvettez06",
    "viper",
    "challengern",
    "cuda",
    "charger69",
    "charger06",
    "mustanggt",
    "monaro",
    "murcielago",
    "slr",
    "carreragt",
    "fordgt",
    "gallardo",
    "sl65",
    "caymans",
    "elise",
    "clk500",
    "brera",
    "mustangshlbyo",
    "jaguarxk",
    "camaron",
    "240sx",
    "eclipse",
    "chevelle",
    "ccx",
    "murcielago640",
    "r8",
    "g35",
    "corolla",
    "is300",
    "mr2",
    "challenger71",
    "mustangshlbyn",
    "gto",
    "roadrunner",
    "911turbo",
    "zonda",
    "997gt3rs",
    "europa",
    "bmwm3gtre46",
    "CROSS",
    "firetruck",
    "dumptruck",
    "cop",
    "cop_gto",
    "cop_corvette",
    "cop_suv",
    "ANGIE",
    "ANGIE_CASINO",
    "BMWM3GTRE46_CROSSCHASE",
    "CARRERA_GRNP7",
    "CE_240SX",
    "CE_350Z",
    "CE_CARRERA_GT",
    "CE_CHALLENGER",
    "CE_CHARGER",
    "CE_GT500",
    "CE_IMPREZA",
    "CE_MURCIELAGO",
    "CE_SKYLINE",
    "CE_SL65",
    "CHEVELLE_2",
    "COLIN",
    "COROLLA_2",
    "CROSS",
    "CS_300C",
    "CS_350Z",
    "CS_BRERA",
    "CS_CAMARO",
    "CS_CAYMANS",
    "CS_CHALLENGERN",
    "CS_CHARGER06",
    "CS_CHARGER69",
    "CS_CLIO",
    "CS_CORVETTEZ06",
    "CS_CUDA",
    "CS_DB9",
    "CS_ECLIPSEGT",
    "CS_GALLARDO",
    "CS_IMPREZAWRXSTI",
    "CS_JAGUARXK",
    "CS_LANCEREVO9",
    "CS_MAZDASPEED3",
    "CS_MUSTANGGT",
    "CS_MUSTANGSHLBYO",
    "CS_RX7",
    "CS_RX8",
    "CS_SKYLINE",
    "CS_SL65",
    "CS_SLR",
    "CS_SUPRA",
    "CS_VIPER",
    "DARIUS",
    "ECLIPSE_2",
    "EUROPA_2",
    "EXOTIC_2",
    "GTO_2",
    "IS300_2",
    "KENJI",
    "KENJI_CASINO",
    "M3GTRCAREERSTART",
    "MR2_2",
    "MUSCLE_2",
    "NIKKI",
    "REVVED",
    "ROADRUNNER_2",
    "SAMSON",
    "T1_COLIN",
    "T1_EXOTIC_NEVILLE",
    "T1_EXOTIC_SAL",
    "T1_MUSCLE_NEVILLE",
    "T1_MUSCLE_SAL",
    "T1_NIKKI",
    "T1_SAMSON",
    "T1_TUNER_NEVILLE",
    "T1_TUNER_SAL",
    "T1_YUMI",
    "T2_EXOTIC_NEVILLE",
    "T2_EXOTIC_SAL",
    "T2_MUSCLE_NEVILLE",
    "T2_MUSCLE_SAL",
    "T2_NIKKI",
    "T2_TUNER_NEVILLE",
    "T2_TUNER_SAL",
    "T3_COLIN",
    "T3_EXOTIC_NEVILLE",
    "T3_EXOTIC_SAL",
    "T3_MUSCLE_NEVILLE",
    "T3_MUSCLE_SAL",
    "T3_SAMSON",
    "T3_TUNER_NEVILLE",
    "T3_TUNER_SAL",
    "T3_YUMI",
    "TUNER_2",
    "WOLF",
    "WOLF_CASINO",
    "YUMI",
    "DEMO_VID_CARRERA",
    "DEMO_VID_GALLARDO",
    "DEMO_VID_CHALLENGER",
    "DEMO_VID_DB9",
    "DEMO_VID_LANCER",
    "DSL_CHALLENGER",
    "DSL_EVO",
    "DSL_EVO2",
    "DSL_GALLARDO",
    "LE_SAMURAI",
    "FOOTMAN",
    "M3GTR_2",
    "USER_EXOTIC",
    "USER_TUNER",
    "USER_MUSCLE",
    "RIVAL_CREW01",
    "RIVAL_CREW02",
    "RIVAL_CREW05",
    "RIVAL_CREW04",
    "CREW_SCORPIOS_BOSS_T3",
    "HERO",
    "PRESELL_RX7",
    "CS_CORVETTEZ06_2",
    "CE_CUDA",
    "M3GTR",
    "copgto",
    "copmidsize",
    "copsport",
    "copsuv",
    "copgtoghost",
    "copghost",
    "copmidsize_ce",
    "copmidsize_nis",
    "copmidsize_nis_ld",
    "copmidsize_weak",
    "copcross",
    "copsportghost",
    "copsporthench",
    "copsuvl",
    "copsuvpatrol",
    "trailera",
    "trailerb",
    "trailerbox",
    "trailercmt",
    "trailercon",
    "trailercrate",
    "trailerlog",
    "semi",
    "cs_semi",
    "semia",
    "semib",
    "semibox",
    "semicmt",
    "semicon",
    "semicrate",
    "semilog",

    // Traffic/Street
    "traf4dseda",
    "traf4dsedb",
    "traf4dsedc",
    "trafcourt",
    "trafficcoup",
    "trafha",
    "trafstwag",
    "traftaxi",

    // Traffic/Truck
    "trafamb",
    "trafcemtr",
    "trafdmptr",
    "traffire",
    "trafgarb",

    // Traffic/Van
    "trafcamper",
    "trafminivan",
    "trafnews",
    "trafpickupa",
    "trafsuva",
    "trafvanb",

    // Choppers
    "copheli",

};

        public static string[] carRealNames = new string[]
{
    "Aston Martin DB9",                     // db9
    "Chevrolet Camaro Concept",             // camaro
    "Chrysler 300C SRT8",                   // 300c
    "Nissan Skyline GT-R (R34)",            // skyline
    "Mitsubishi Lancer Evolution IX MR",    // lancerevo9
    "Toyota Supra",                         // supra
    "Subaru Impreza WRX STI",               // imprezawrxsti
    "Nissan 350Z (Z33)",                    // 350z
    "Mazda RX-7 (FD3S)",                    // rx7
    "Renault Clio V6",                      // clio
    "Volkswagen Golf R32",                  // r32
    "Mitsubishi Eclipse GT",                // eclipsegt
    "Mazdaspeed3",                          // mazdaspeed3
    "Mazda RX-8",                           // rx8
    "Chevrolet Corvette Z06 (C6)",          // corvettez06
    "Dodge Viper SRT-10",                   // viper
    "Dodge Challenger Concept",             // challengern
    "Plymouth Hemi 'Cuda",                  // cuda
    "Dodge Charger R/T (1969)",             // charger69
    "Dodge Charger SRT8 (2006)",            // charger06
    "Ford Mustang GT",                      // mustanggt
    "Vauxhall Monaro VXR",                  // monaro
    "Lamborghini Murciélago",               // murcielago
    "Mercedes-Benz SLR McLaren",            // slr
    "Porsche Carrera GT",                   // carreragt
    "Ford GT",                              // fordgt
    "Lamborghini Gallardo",                 // gallardo
    "Mercedes-Benz SL 65 AMG",              // sl65
    "Porsche Cayman S",                     // caymans
    "Lotus Elise 111R",                     // elise
    "Mercedes-Benz CLK 500",                // clk500
    "Alfa Romeo Brera",                     // brera
    "Shelby GT500 (1967)",                  // mustangshlbyo
    "Jaguar XK Convertible",                // jaguarxk
    "Chevrolet Camaro SS (1967)",           // camaron
    "Nissan 240SX (S13)",                   // 240sx
    "Mitsubishi Eclipse GSX (1999)",        // eclipse
    "Chevrolet Chevelle SS",                // chevelle
    "Koenigsegg CCX",                       // ccx
    "Lamborghini Murciélago LP640",         // murcielago640
    "Audi R8 (Le Mans Quattro)",            // r8
    "Infiniti G35",                         // g35
    "Toyota Corolla GTS (AE86)",            // corolla
    "Lexus IS300",                          // is300
    "Toyota MR2",                           // mr2
    "Dodge Challenger R/T (1971)",          // challenger71
    "Shelby GT500 (2007)",                  // mustangshlbyn
    "Pontiac GTO (1965)",                   // gto
    "Plymouth Road Runner",                 // roadrunner
    "Porsche 911 Turbo (997)",              // 911turbo
    "Pagani Zonda F",                       // zonda
    "Porsche 911 GT3 RS (997)",             // 997gt3rs
    "Lotus Europa S",                       // europa
    "BMW M3 GTR (E46)",                     // bmwm3gtre46
    "Cross's Chevrolet Corvette Z06",       // CROSS
    "Fire Truck",                           // firetruck
    "Dump Truck",                           // dumptruck
    "Civic Cruiser (Cop Tier 1)",           // cop
    "Interceptor (Cop GTO Tier 2)",         // cop_gto
    "Rhino (Cop SUV)",                      // cop_suv
    "Collector's Edition 240SX",            // CE_240SX
    "Collector's Edition 350Z",             // CE_350Z
    "Collector's Edition Carrera GT",       // CE_CARRERA_GT
    "Collector's Edition Challenger",       // CE_CHALLENGER
    "Collector's Edition Charger",          // CE_CHARGER
    "Collector's Edition Shelby GT500",     // CE_GT500
    "Collector's Edition Impreza",          // CE_IMPREZA
    "Collector's Edition Murciélago",       // CE_MURCIELAGO
    "Collector's Edition Skyline",          // CE_SKYLINE
    "Collector's Edition SL65",             // CE_SL65
    "Samson's Plymouth 'Cuda (Revved)",     // REVVED
    "Custom Gallardo (Challenge Series)",   // CS_GALLARDO
    "Online Muscle Car",                    // ONLINE_MUSCLE
    "Kenji's Mazda RX-8 (Challenge Series)",// CS_RX8
    "Custom Mustang GT (Challenge Series)", // CS_MUSTANGGT
    "State Interceptor (Cop GTO)",          // copgto
    "Civic Cruiser (Cop Midsize)",          // copmidsize
    "Undercover Cruiser (Cop Sport)",       // copsport
    "Rhino (Cop SUV Heavy)",                // copsuv
    "State Interceptor Ghost (GTO)",        // copgtoghost
    "Undercover Cruiser (Ghost)",           // copghost
    "Civic Cruiser (CE)",                   // copmidsize_ce
    "Civic Cruiser (Intro Movie)",          // copmidsize_nis
    "Civic Cruiser (Intro Movie Light)",    // copmidsize_nis_ld
    "Civic Cruiser (Weak)",                 // copmidsize_weak
    "Cross's Corvette (Cop)",               // copcross
    "Undercover Cruiser Ghost (Sport)",     // copsportghost
    "Undercover Cruiser Henchman (Sport)",  // copsporthench
    "Rhino (Cop SUV Light)",                // copsuvl
    "Rhino (Cop SUV Patrol)",               // copsuvpatrol
    "Trailer A (Flatbed)",                  // trailera
    "Trailer B (Flatbed Empty)",            // trailerb
    "Trailer (Box)",                        // trailerbox
    "Trailer (Cement)",                     // trailercmt
    "Trailer (Container)",                  // trailercon
    "Trailer (Crate)",                      // trailercrate
    "Trailer (Logs)",                       // trailerlog
    "Semi Truck",                           // semi
    "Challenge Series Semi Truck",                    // cs_semi
    "Semi Truck A",                         // semia
    "Semi Truck B",                         // semib
    "Semi Truck (Box)",                     // semibox
    "Semi Truck (Cement)",                  // semicmt
    "Semi Truck (Container)",               // semicon
    "Semi Truck (Crate)",                   // semicrate
    "Semi Truck (Logs)",                    // semilog

    // Traffic/Street
    "Traffic Sedan A",                      // traf4dseda
    "Traffic Sedan B",                      // traf4dsedb
    "Traffic Sedan C",                      // traf4dsedc
    "Traffic Coupe",                        // trafcourt
    "Traffic Hatchback (Coupe)",            // trafficcoup
    "Traffic Hatchback A",                  // trafha
    "Traffic Station Wagon",                // trafstwag
    "Traffic Taxi",                         // traftaxi

    // Traffic/Truck
    "Traffic Ambulance",                    // trafamb
    "Traffic Cement Truck",                 // trafcemtr
    "Traffic Dump Truck",                   // trafdmptr
    "Traffic Fire Truck",                   // traffire
    "Traffic Garbage Truck",                // trafgarb

    // Traffic/Van
    "Traffic Camper Van",                   // trafcamper
    "Traffic Minivan",                      // trafminivan
    "Traffic News Van",                     // trafnews
    "Traffic Pickup Truck",                 // trafpickupa
    "Traffic SUV",                          // trafsuva
    "Traffic Delivery Van",                 // trafvanb

    // Choppers
    "Police Helicopter"                     // copheli
};

        public static string[] pvehicle = new string[]
{
    // --- Custom / Beta ---
    "997gt3rs",
    "bmwm3gtre46",
    "camaron",
    "ccx",
    "chevelle",
    "player_cop",
    "player_cop_corvette",
    "player_cop_gto",
    "player_cop_suv",
    "corolla",
    "player_dumptruck",
    "eclipse",
    "europa",
    "player_firetruck",
    "gto",
    "is300",
    "mr2",
    "murcielago640",
    "mustangshlbyn",
    "r8",
    "roadrunner",
    "zonda",
    "copter",
    "911turbo",

    // --- Exotics ---
    "997tt",
    "bmwm3gtre46_crosschase",
    "m3gtrcareerstart",
    "brera",
    "t1_exotic_neville",
    "carreragt",
    "carrera_gmp7",
    "temp_exotic_03",
    "caymans",
    "colin",
    "clk500",
    "db9",
    "wolf",
    "elise",
    "fordgt",
    "nikki",
    "gallardo",
    "demo_vid_gallardo",
    "jaguarxk",
    "footman",
    "murcielago",
    "wolf_casino",
    "darius",
    "darius_ai",
    "sl65",
    "slr",

    // --- Muscles ---
    "300c",
    "t1_muscle_neville",
    "camaro",
    "challenger71",
    "challengem",
    "angie_casino",
    "angie_casinoai",
    "charger06",
    "charger69",
    "angie",
    "samson",
    "temp_muscle_02",
    "corvettez06",
    "cross",
    "cuda",
    "temp_muscle_01",
    "monaro",
    "mustanggt",
    "mustangshlbyo",
    "viper",

    // --- Tuners ---
    "240sx",
    "350z",
    "clio",
    "eclipsegt",
    "yumi",
    "g35",
    "imprezawrxsti",
    "wrx_red",
    "lancerevo9",
    "kenji_casino",
    "mazdaspeed3",
    "t1_tuner_neville",
    "r32",
    "rx7",
    "kenji",
    "rival_kenji",
    "rx8",
    "skyline",
    "supra",
    "hero",

    // --- Traffic / Street / Trailers ---
    "semi",
    "cs_semi",
    "semia",
    "semib",
    "semibox",
    "semicmt",
    "semicon",
    "semicrate",
    "semilog",
    "traf4dseda",
    "traf4dsedb",
    "traf4dsedc",
    "trafcourt",
    "trafficcoup",
    "trafha",
    "trafstwag",
    "traftaxi",
    "trafamb",
    "trafcemtr",
    "trafdmptr",
    "traffire",
    "trafgarb",
    "trafcamper",
    "trafminivan",
    "trafnews",
    "trafpickupa",
    "trafsuva",
    "trafvanb",
    "trailera",
    "trailerb",
    "trailerbox",
    "trailercmt",
    "trailercon",
    "trailercrate",
    "trailerlog",

    // --- Police ---
    "copgto",
    "copmidsize",
    "copsport",
    "copsuv",
    "copgtoghost",
    "copghost",
    "copmidsize_ce",
    "copmidsize_nis",
    "copmidsize_nis_ld",
    "copmidsize_weak",
    "copcross",
    "copsportghost",
    "copsporthench",
    "copsuvl",
    "copsuvpatrol",
    "copheli"
};

      
public static string[] pvehicle_List_names = new string[]
{
    // --- Custom / Beta ---
    "Porsche 911 GT3 RS (997)",
    "BMW M3 GTR (E46) [Beta/Custom]",
    "Chevrolet Camaro Concept [Beta]",
    "Koenigsegg CCX",
    "Chevrolet Chevelle SS",
    "Player Cop Car (GTO)",
    "Player Cop Corvette",
    "Player Cop GTO",
    "Player Cop SUV",
    "Toyota Corolla GTS (AE86)",
    "Player Dump Truck",
    "Mitsubishi Eclipse GSX",
    "Lotus Europa S",
    "Player Fire Truck",
    "Pontiac GTO",
    "Lexus IS300",
    "Toyota MR2",
    "Lamborghini Murciélago LP640",
    "Ford Mustang Shelby GT500 [Beta/Custom]",
    "Audi R8 / LeMans quattro",
    "Plymouth Road Runner",
    "Pagani Zonda F",
    "News Helicopter",
    "Porsche 911 Turbo (997) [Beta]",

    // --- Exotics ---
    "Porsche 911 Turbo (997)",
    "BMW M3 GTR (E46) [Cross Chase Preset]",
    "BMW M3 GTR (E46) [Career Start]",
    "Alfa Romeo Brera",
    "Neville's Alfa Romeo Brera (Tier 1)",
    "Porsche Carrera GT",
    "Porsche Carrera GT [GMP7 Preset]",
    "Lotus Elise [Temp Exotic 03]",
    "Porsche Cayman S",
    "Colin's Porsche Cayman S",
    "Mercedes-Benz CLK 500",
    "Aston Martin DB9",
    "Wolf's Aston Martin DB9",
    "Lotus Elise",
    "Ford GT",
    "Nikki's Ford GT",
    "Lamborghini Gallardo",
    "Lamborghini Gallardo [Demo Video]",
    "Jaguar XK Convertible",
    "Sal's Mazda RX-8 / Lamborghini Gallardo",
    "Lamborghini Murciélago",
    "Wolf's Lamborghini Murciélago (Casino)",
    "Darius's Audi LeMans quattro",
    "Darius's Audi LeMans quattro (AI)",
    "Mercedes-Benz SL 65 AMG",
    "Mercedes-Benz SLR McLaren",

    // --- Muscles ---
    "Chrysler 300C SRT8",
    "Neville's Chrysler 300C (Tier 1)",
    "Chevrolet Camaro Concept",
    "Dodge Challenger (1971)",
    "Dodge Challenger Concept",
    "Angie's Dodge Charger R/T (Casino)",
    "Angie's Dodge Charger R/T (Casino AI)",
    "Dodge Charger SRT8 (2006)",
    "Dodge Charger R/T (1969)",
    "Angie's Dodge Charger R/T",
    "Samson's Plymouth Hemi Cuda",
    "Ford Mustang GT [Temp Muscle 02]",
    "Chevrolet Corvette Z06",
    "Cross's Chevrolet Corvette Z06",
    "Plymouth Hemi Cuda",
    "Chevrolet Camaro Concept [Temp Muscle 01]",
    "Vauxhall Monaro VXR",
    "Ford Mustang GT",
    "Ford Mustang Shelby GT500",
    "Dodge Viper SRT-10",

    // --- Tuners ---
    "Nissan 240SX",
    "Nissan 350Z",
    "Renault Clio V6",
    "Mitsubishi Eclipse GT",
    "Yumi's Mazda RX-8",
    "Infiniti G35",
    "Subaru Impreza WRX STI",
    "Subaru Impreza WRX STI [Red Preset]",
    "Mitsubishi Lancer Evolution IX",
    "Kenji's Mazda RX-7 (Casino)",
    "Mazdaspeed 3",
    "Neville's Mazda RX-8 (Tier 1)",
    "Volkswagen Golf R32",
    "Mazda RX-7",
    "Kenji's Mazda RX-7",
    "Kenji's Mitsubishi Lancer Evolution IX (Rival)",
    "Mazda RX-8",
    "Nissan Skyline GT-R (R34)",
    "Toyota Supra",
    "Player's Custom Car [Hero]",

    // --- Traffic / Street / Trailers ---
    "Traffic Semi Truck",
    "Traffic Semi Truck (Cutscene)",
    "Traffic Semi Truck A",
    "Traffic Semi Truck B",
    "Traffic Semi Truck (Box Trailer)",
    "Traffic Semi Truck (Cement Mixer)",
    "Traffic Semi Truck (Container)",
    "Traffic Semi Truck (Crate Trailer)",
    "Traffic Semi Truck (Log Trailer)",
    "Traffic 4-Door Sedan A",
    "Traffic 4-Door Sedan B",
    "Traffic 4-Door Sedan C",
    "Traffic Court Car",
    "Traffic Coupe",
    "Traffic Hatchback A",
    "Traffic Station Wagon",
    "Traffic Taxi",
    "Traffic Ambulance",
    "Traffic Cement Truck",
    "Traffic Dump Truck",
    "Traffic Fire Truck",
    "Traffic Garbage Truck",
    "Traffic Camper Van",
    "Traffic Minivan",
    "Traffic News Van",
    "Traffic Pickup Truck A",
    "Traffic SUV A",
    "Traffic Panel Van B",
    "Traffic Trailer A",
    "Traffic Trailer B",
    "Traffic Box Trailer",
    "Traffic Cement Trailer",
    "Traffic Container Trailer",
    "Traffic Crate Trailer",
    "Traffic Log Trailer",

    // --- Police ---
    "Undercover Police GTO (Heat 4)",
    "Civic Police Cruiser (Heat 1)",
    "State Police Pursuit Car (Heat 3)",
    "Rhino Police SUV (Heat 2/4)",
    "Ghost Police GTO",
    "Ghost Police Cruiser",
    "Civic Police Cruiser (Collector's Edition)",
    "Civic Police Cruiser (Intro / NIS)",
    "Civic Police Cruiser (Intro Light Damage)",
    "Civic Police Cruiser (Weak Variant)",
    "Cross's Police Corvette Z06",
    "Ghost State Police Pursuit Car",
    "Henchmen State Police Pursuit Car",
    "Rhino Police SUV Light",
    "Rhino Police SUV Patrol",
    "Police Helicopter"
};





        public static uint[] Performance_Parts = new uint[]
        {
            // --- Performance Parts ---
    // Engine
    0x92037DAD, 0x92037DAE, // Stage 1
    0x920381EE, 0x920381EF, // Stage 2
    0x9203862F, 0x92038630, 0x92038631, // Stage 3

    // Transmission
    0x8C41C401, 0x8C41C402, // Stage 1
    0x8C41C842, 0x8C41C843, // Stage 2
    0x8C41CC83, 0x8C41CC84, 0x8C41CC85, // Stage 3

    // Suspension
    0x3C92A392, 0x3C92A393, // Stage 1
    0x3C92A7D3, 0x3C92A7D4, // Stage 2
    0x3C92AC14, 0x3C92AC15, 0x3C92AC16, // Stage 3

    // Nitrous
    0xEB637DE7, 0xEB637DE8, 0xEB637DE9, // Stage 1
    0xEB638228, 0xEB638229, 0xEB63822A, // Stage 2
    0xEB638669, 0xEB63866A, 0xEB63866B, // Stage 3

    // Tires
    0xFC612CDE, 0xFC612CDF, // Stage 1
    0xFC61311F, 0xFC613120, // Stage 2
    0xFC613560, 0xFC613561, 0xFC613562, // Stage 3

    // Brakes
    0x543DF3EF, 0x543DF3F0, // Stage 1
    0x543DF830, 0x543DF831, // Stage 2
    0x543DFC71, 0x543DFC72, 0x543DFC73, // Stage 3

    // Forced Induction (Turbo/Supercharger)
    0x97D4AC84, 0x97D4AC85, // Stage 1
    0x97D4B0C5, 0x97D4B0C6, // Stage 2
    0x97D4B506, 0x97D4B507, 0x97D4B508 // Stage 3
        };

        public static uint[] All_Visuals_List = new uint[]
        {
            // --- Paint (Body) ---
    0xBEE5AC6B, 0xBEE5AC6C, 0xBEE5AC6D, 0xBEE5AC6E, 0xBEE5AC6F, 0xBEE5AC70, 0xBEE5AC71,
    
    // --- Wheel Paint ---
    0x0EC591F3, 0x0EC591F5, 0x0EC591F6, 
    // --- Vinyls ---
    0x996465D3, 0x996465D4, 0x996465D5, 0x996465D6, 0x996465D7, 0x996465D8, 0x996465D9, 0x996465DA, 0x996465DB, 0x996465DC, 0xC5F12084, 0xC5F12085, 0xC5F12086, 0xC5F12087, 0xC5F12088, 0xC5F1208A, 0xC5F1208B, 0xC5F1208C,
    // Bonus/Special Vinyls
    0x79B7FFBF, 0xB0B7F7D1, 0xB0B7F7D2, 0xB0B7F7D3, 0xB0B7F7D4, 0xB0AFFD67, 0xC7708D4E, 0xB0B938BC, 0xC7EE93E7, 0xC7FCD97E, 0xB0B03891, 0x03B03C5B, 0xC72B92F9, 0xB0B99AA3, 0xA4107C79, 0x70F46603, 0xC8D6AD51, 0x464F7478, 0xC5C40E88, 0x02BE3A3E, 0x71E356E8, 0x0F8D117D, 0x76453AD3, 0xC5F120A5,
    // Online/Virus Vinyls
    0x79B7C9BF, 0xC7A0F120, 0xB4277C66, 0xF1CB205A, 0xEEB55CE2, 0xD26D7E14, 0x233AB70D, 0x5CC5E5E3, 0x89DDDCBC, 0x9A560CD3, 0x5614AE93, 0xBB7DA0E9,

    // --- Window Tint ---
    // Light
    0x89946400, 0xE398A5B8, 0x803EB1BE, 0xF14F0E3F, 0x89F23A14, 0x880C43AB, 0xCC9AEFDD, 0xEA999A36,
    // Dark
    0xD68EA0C1, 0xCFDA7A99, 0x8050CA3F, 0xDD90E320, 0xD6EC76D5, 0x8A616C4C, 0xB8DCC4BE, 0xD6DB6F17,
    // Pearl
    0xFD1A4DD5, 0xC7DBCA2D, 0x5C262253, 0xD59232B4, 0xFD7823E9, 0xE0E1C6E0, 0xB0DE1452, 0xCEDCBEAB,
        };

        public static uint[] All_Body_Parts = new uint[]
        {
            // --- AutoSculpt Wheels ---
    0x8877780D, 0x8877780E, 0x8877780F, 0x88777810, 0x88777811, 0x88777812, 0x88777813, 0x88777814, 0x88777815,

    // --- AutoSculpt Body ---
    // Front Bumper
    0x0CABE990, 0xAB6D7CF7, 0xE6ADB698, 0x702D4356, 0x74B31DB0, 0x47EC2331, 0x832C5CD2, 0xBE6C9673, 0xF9ACD014, 0x34ED09B5,
    // Rear Bumper
    0x348B7B51, 0x6024BDD8, 0xAF83C759, 0x10C5B457, 0x206CAB71, 0x83EA84D2, 0xD3498E53, 0x22A897D4, 0x7207A155, 0xC166AAD6,
    // Skirts
    0x40D7908A, 0x5BAF39D1, 0xA8A97692, 0x0EB4FD10, 0xE01F28AA, 0x8DD1CD4B, 0xDACC0A0C, 0x27C646CD, 0x74C0838E, 0xC1BAC04F,
    // Hoods
    0x96BC34D7, 0x6E42CEDF, 0x6E42CEE0, 0x6E42CEE1, 0x6E42CEE2, 0x6E42CEE3, 0x6E42CEE4, 0x6E42CEE5,
    // Exhaust Tips
    0xD8945DC7, 0xD8945DC8, 0xD8945DC9, 0xD8945DCA, 0xD8945DCB, 0xD8945DCC, 0xD8945DCD, 0xD8945DCE, 0xD8945DCF, 0xEB2016D7, 0xEB2016D8, 0xEB2016D9, 0xEB2016DA, 0xEB2016DB, 0xEB2016DC, 0xEB2016DD, 0xEB2016DE,

    // --- Aftermarket ---
    // Body Kits
    0x9FA9D8A3, 0x9FA9D8A4, 0x9FA9D8A5, 0x9FA9D8A6, 0x9FA9D8A7,
    // Hoods (Normal)
    0x96BC34CF, 0x96BC34D0, 0x96BC34D1, 0x96BC34D2, 0x96BC34D3, 0x96BC34D4, 0x96BC34D5, 0x96BC34D6,
    // Hoods (Carbon Fiber)
    0x0A3C4B77, 0x0A3C4B78, 0x0A3C4B79, 0x0A3C4B7A, 0x0A3C4B7B, 0x0A3C4B7C, 0x0A3C4B7D, 0x0A3C4B7E,

    // Roof Scoops (Normal & Dual)
    0xAE0FD39B, 0xAE0FD39C, 0xAE0FD39D, 0xAE0FD39F, 0xAE0FD3A3, 0x700A472B, 0x700A472C, 0x700A472F, 0x700A4730, 0x700A4732, 0x700A4733, 0x70592060, 0x72AE4901, 0x750371A2, 0x79ADC2E4, 0x83026568, 0x0FBA4DF0, 0x120F7691, 0x190EF074, 0x1B641915, 0x200E6A57, 0x226392F8,
    // Roof Scoops (Carbon Fiber & Dual)
    0x9BB98EC3, 0x9BBA1B24, 0x9BBAA785, 0x9BBBC047, 0x9BBDF1CB, 0x12D21853, 0x12D2A4B4, 0x12D449D7, 0x12D4D638, 0x12D5EEFA, 0x12D67B5B, 0xE19E1488, 0x561A8589, 0xCA96F68A, 0xB38FD88C, 0x85819C90, 0x6A5B1818, 0xDED78919, 0x3C4CDC1C, 0xB0C94D1D, 0x99C22F1F, 0x0E3EA020,

    // Spoilers (Normal)
    0x022A40C3, 0x022A40C4, 0x022A40C5, 0x022A40C6, 0x022A40C7, 0x022A40C8, 0x022A40C9, 0x022A40CA, 0x022A40CB, 0x47725953, 0x47725954, 0x47725955, 0x47725956, 0x47725957, 0x47725958, 0x47725959, 0x4772595A, 0x4772595B, 0x4772595C, 0x47725974, 0x47725975, 0x47725976, 0x47725977, 0x47725978, 0x47725979, 0x4772597A, 0x4772597B, 0x4772597C, 0x4772597D,
    // Spoilers (Carbon Fiber)
    0xED6ECAEB, 0xED6F574C, 0xED6FE3AD, 0xED70700E, 0xED70FC6F, 0xED7188D0, 0xED721531, 0xED72A192, 0xED732DF3, 0x9B2ED97B, 0x9B2F65DC, 0x9B2FF23D, 0x9B307E9E, 0x9B310AFF, 0x9B319760, 0x9B3223C1, 0x9B32B022, 0x9B333C83, 0x9B33C8E4, 0x9B40F1FC, 0x9B417E5D, 0x9B420ABE, 0x9B42971F, 0x9B432380, 0x9B43AFE1, 0x9B443C42, 0x9B44C8A3, 0x9B455504, 0x9B45E165,

    // --- Aftermarket Wheels ---
    0x3DF7486B, 0x3DF7486C, 0x3DF7486D, 0x3DF7486E, 0x3DF7486F, 0x285C5650, 0x285C5651, 0x285C5652, 0x285C5653, 0x285C5654, 0x854F11D9, 0x854F11DA, 0x854F11DB, 0xB0395F6D, 0xB0395F6E, 0xB0395F6F, 0xB0395F70, 0x47129AA2, 0x47129AA3, 0x47129AA4, 0x47129AA5, 0x47129AA6, 0xD54AFEDC, 0xD54AFEDD, 0xD54AFEDE, 0xD54AFEDF, 0x5C510405, 0x5C510406, 0x5C510407, 0x69684169, 0x6968416A, 0x6968416B, 0x283CAA8C, 0x283CAA8D, 0x283CAA8E, 0x28E277D8, 0x28E277D9, 0x28E277DA, 0x89198899, 0x8919889A, 0x8919889B, 0xCBE64071, 0xCBE64072, 0xCBE64073, 0x286D5A50, 0x286D5A51, 0x286D5A52, 0x286D5A53, 0x286D5A54, 0x286D5A55, 0x470BCA88, 0x470BCA89, 0x470BCA8A, 0x470BCA8B, 0xFB7B38C5, 0xFB7B38C6, 0xFB7B38C7, 0xFB7B38C8, 0x29BC76D7, 0x29BC76D8, 0x29BC76D9, 0x65A6E9D5, 0x65A6E9D6, 0x65A6E9D7, 0x67FF5CBC, 0x67FF5CBD, 0x67FF5CBE, 0x67FF5CBF

        };
        

        public static uint[] Parts_Master_List = new uint[]
{
    // --- Performance Parts ---
    // Engine
    0x92037DAD, 0x92037DAE, // Stage 1
    0x920381EE, 0x920381EF, // Stage 2
    0x9203862F, 0x92038630, 0x92038631, // Stage 3

    // Transmission
    0x8C41C401, 0x8C41C402, // Stage 1
    0x8C41C842, 0x8C41C843, // Stage 2
    0x8C41CC83, 0x8C41CC84, 0x8C41CC85, // Stage 3

    // Suspension
    0x3C92A392, 0x3C92A393, // Stage 1
    0x3C92A7D3, 0x3C92A7D4, // Stage 2
    0x3C92AC14, 0x3C92AC15, 0x3C92AC16, // Stage 3

    // Nitrous
    0xEB637DE7, 0xEB637DE8, 0xEB637DE9, // Stage 1
    0xEB638228, 0xEB638229, 0xEB63822A, // Stage 2
    0xEB638669, 0xEB63866A, 0xEB63866B, // Stage 3

    // Tires
    0xFC612CDE, 0xFC612CDF, // Stage 1
    0xFC61311F, 0xFC613120, // Stage 2
    0xFC613560, 0xFC613561, 0xFC613562, // Stage 3

    // Brakes
    0x543DF3EF, 0x543DF3F0, // Stage 1
    0x543DF830, 0x543DF831, // Stage 2
    0x543DFC71, 0x543DFC72, 0x543DFC73, // Stage 3

    // Forced Induction (Turbo/Supercharger)
    0x97D4AC84, 0x97D4AC85, // Stage 1
    0x97D4B0C5, 0x97D4B0C6, // Stage 2
    0x97D4B506, 0x97D4B507, 0x97D4B508, // Stage 3

    // --- Paint (Body) ---
    0xBEE5AC6B, 0xBEE5AC6C, 0xBEE5AC6D, 0xBEE5AC6E, 0xBEE5AC6F, 0xBEE5AC70, 0xBEE5AC71,
    
    // --- Wheel Paint ---
    0x0EC591F3, 0x0EC591F5, 0x0EC591F6,

    // --- AutoSculpt Wheels ---
    0x8877780D, 0x8877780E, 0x8877780F, 0x88777810, 0x88777811, 0x88777812, 0x88777813, 0x88777814, 0x88777815,

    // --- AutoSculpt Body ---
    // Front Bumper
    0x0CABE990, 0xAB6D7CF7, 0xE6ADB698, 0x702D4356, 0x74B31DB0, 0x47EC2331, 0x832C5CD2, 0xBE6C9673, 0xF9ACD014, 0x34ED09B5,
    // Rear Bumper
    0x348B7B51, 0x6024BDD8, 0xAF83C759, 0x10C5B457, 0x206CAB71, 0x83EA84D2, 0xD3498E53, 0x22A897D4, 0x7207A155, 0xC166AAD6,
    // Skirts
    0x40D7908A, 0x5BAF39D1, 0xA8A97692, 0x0EB4FD10, 0xE01F28AA, 0x8DD1CD4B, 0xDACC0A0C, 0x27C646CD, 0x74C0838E, 0xC1BAC04F,
    // Hoods
    0x96BC34D7, 0x6E42CEDF, 0x6E42CEE0, 0x6E42CEE1, 0x6E42CEE2, 0x6E42CEE3, 0x6E42CEE4, 0x6E42CEE5,
    // Exhaust Tips
    0xD8945DC7, 0xD8945DC8, 0xD8945DC9, 0xD8945DCA, 0xD8945DCB, 0xD8945DCC, 0xD8945DCD, 0xD8945DCE, 0xD8945DCF, 0xEB2016D7, 0xEB2016D8, 0xEB2016D9, 0xEB2016DA, 0xEB2016DB, 0xEB2016DC, 0xEB2016DD, 0xEB2016DE,

    // --- Aftermarket ---
    // Body Kits
    0x9FA9D8A3, 0x9FA9D8A4, 0x9FA9D8A5, 0x9FA9D8A6, 0x9FA9D8A7,
    // Hoods (Normal)
    0x96BC34CF, 0x96BC34D0, 0x96BC34D1, 0x96BC34D2, 0x96BC34D3, 0x96BC34D4, 0x96BC34D5, 0x96BC34D6,
    // Hoods (Carbon Fiber)
    0x0A3C4B77, 0x0A3C4B78, 0x0A3C4B79, 0x0A3C4B7A, 0x0A3C4B7B, 0x0A3C4B7C, 0x0A3C4B7D, 0x0A3C4B7E,

    // Roof Scoops (Normal & Dual)
    0xAE0FD39B, 0xAE0FD39C, 0xAE0FD39D, 0xAE0FD39F, 0xAE0FD3A3, 0x700A472B, 0x700A472C, 0x700A472F, 0x700A4730, 0x700A4732, 0x700A4733, 0x70592060, 0x72AE4901, 0x750371A2, 0x79ADC2E4, 0x83026568, 0x0FBA4DF0, 0x120F7691, 0x190EF074, 0x1B641915, 0x200E6A57, 0x226392F8,
    // Roof Scoops (Carbon Fiber & Dual)
    0x9BB98EC3, 0x9BBA1B24, 0x9BBAA785, 0x9BBBC047, 0x9BBDF1CB, 0x12D21853, 0x12D2A4B4, 0x12D449D7, 0x12D4D638, 0x12D5EEFA, 0x12D67B5B, 0xE19E1488, 0x561A8589, 0xCA96F68A, 0xB38FD88C, 0x85819C90, 0x6A5B1818, 0xDED78919, 0x3C4CDC1C, 0xB0C94D1D, 0x99C22F1F, 0x0E3EA020,

    // Spoilers (Normal)
    0x022A40C3, 0x022A40C4, 0x022A40C5, 0x022A40C6, 0x022A40C7, 0x022A40C8, 0x022A40C9, 0x022A40CA, 0x022A40CB, 0x47725953, 0x47725954, 0x47725955, 0x47725956, 0x47725957, 0x47725958, 0x47725959, 0x4772595A, 0x4772595B, 0x4772595C, 0x47725974, 0x47725975, 0x47725976, 0x47725977, 0x47725978, 0x47725979, 0x4772597A, 0x4772597B, 0x4772597C, 0x4772597D,
    // Spoilers (Carbon Fiber)
    0xED6ECAEB, 0xED6F574C, 0xED6FE3AD, 0xED70700E, 0xED70FC6F, 0xED7188D0, 0xED721531, 0xED72A192, 0xED732DF3, 0x9B2ED97B, 0x9B2F65DC, 0x9B2FF23D, 0x9B307E9E, 0x9B310AFF, 0x9B319760, 0x9B3223C1, 0x9B32B022, 0x9B333C83, 0x9B33C8E4, 0x9B40F1FC, 0x9B417E5D, 0x9B420ABE, 0x9B42971F, 0x9B432380, 0x9B43AFE1, 0x9B443C42, 0x9B44C8A3, 0x9B455504, 0x9B45E165,

    // --- Aftermarket Wheels ---
    0x3DF7486B, 0x3DF7486C, 0x3DF7486D, 0x3DF7486E, 0x3DF7486F, 0x285C5650, 0x285C5651, 0x285C5652, 0x285C5653, 0x285C5654, 0x854F11D9, 0x854F11DA, 0x854F11DB, 0xB0395F6D, 0xB0395F6E, 0xB0395F6F, 0xB0395F70, 0x47129AA2, 0x47129AA3, 0x47129AA4, 0x47129AA5, 0x47129AA6, 0xD54AFEDC, 0xD54AFEDD, 0xD54AFEDE, 0xD54AFEDF, 0x5C510405, 0x5C510406, 0x5C510407, 0x69684169, 0x6968416A, 0x6968416B, 0x283CAA8C, 0x283CAA8D, 0x283CAA8E, 0x28E277D8, 0x28E277D9, 0x28E277DA, 0x89198899, 0x8919889A, 0x8919889B, 0xCBE64071, 0xCBE64072, 0xCBE64073, 0x286D5A50, 0x286D5A51, 0x286D5A52, 0x286D5A53, 0x286D5A54, 0x286D5A55, 0x470BCA88, 0x470BCA89, 0x470BCA8A, 0x470BCA8B, 0xFB7B38C5, 0xFB7B38C6, 0xFB7B38C7, 0xFB7B38C8, 0x29BC76D7, 0x29BC76D8, 0x29BC76D9, 0x65A6E9D5, 0x65A6E9D6, 0x65A6E9D7, 0x67FF5CBC, 0x67FF5CBD, 0x67FF5CBE, 0x67FF5CBF,

    // --- Vinyls ---
    0x996465D3, 0x996465D4, 0x996465D5, 0x996465D6, 0x996465D7, 0x996465D8, 0x996465D9, 0x996465DA, 0x996465DB, 0x996465DC, 0xC5F12084, 0xC5F12085, 0xC5F12086, 0xC5F12087, 0xC5F12088, 0xC5F1208A, 0xC5F1208B, 0xC5F1208C,
    // Bonus/Special Vinyls
    0x79B7FFBF, 0xB0B7F7D1, 0xB0B7F7D2, 0xB0B7F7D3, 0xB0B7F7D4, 0xB0AFFD67, 0xC7708D4E, 0xB0B938BC, 0xC7EE93E7, 0xC7FCD97E, 0xB0B03891, 0x03B03C5B, 0xC72B92F9, 0xB0B99AA3, 0xA4107C79, 0x70F46603, 0xC8D6AD51, 0x464F7478, 0xC5C40E88, 0x02BE3A3E, 0x71E356E8, 0x0F8D117D, 0x76453AD3, 0xC5F120A5,
    // Online/Virus Vinyls
    0x79B7C9BF, 0xC7A0F120, 0xB4277C66, 0xF1CB205A, 0xEEB55CE2, 0xD26D7E14, 0x233AB70D, 0x5CC5E5E3, 0x89DDDCBC, 0x9A560CD3, 0x5614AE93, 0xBB7DA0E9,

    // --- Window Tint ---
    // Light
    0x89946400, 0xE398A5B8, 0x803EB1BE, 0xF14F0E3F, 0x89F23A14, 0x880C43AB, 0xCC9AEFDD, 0xEA999A36,
    // Dark
    0xD68EA0C1, 0xCFDA7A99, 0x8050CA3F, 0xDD90E320, 0xD6EC76D5, 0x8A616C4C, 0xB8DCC4BE, 0xD6DB6F17,
    // Pearl
    0xFD1A4DD5, 0xC7DBCA2D, 0x5C262253, 0xD59232B4, 0xFD7823E9, 0xE0E1C6E0, 0xB0DE1452, 0xCEDCBEAB,

    
};




        public static void Read_Decompressed_Data(byte[] Data, ref TextBox Name, ref TextBox Money, ref TextBox Crew_Name,  ref NumericUpDown Strike_Markers, ref NumericUpDown Get_Out_Of_Jail_Markers, ref ComboBox Garage_Theme, ref int Selected_Player_Car,  ref int Crew_1_ID, ref byte Crew_1_Car_Slot, ref int Crew_2_ID, ref byte Crew_2_Car_Slot, ref int Crew_3_ID, ref byte Crew_3_Car_Slot)
        {
            string jdlzString = System.Text.Encoding.ASCII.GetString(Data);
            string[] lines = jdlzString.Split('\n');
            string player_Name = "";
            string currentMoney = "";
            string Array_Count_Unlocks = "";
            string[] Array_Unlockables;
            string[] Career_Unlocks = new string[100];
            foreach (string line in lines)
            {
                string[] tabs = line.Split('\t');
                string label = tabs[0]; // Remove the colon from the label

                switch (label)
                {
                    case "841929775:":
                        {// Names
                            Name.Text = tabs[1];
                            Name.Text = Name.Text.Replace("\"", "");
                            break;
                        }
                    case "2287685084:": // Money
                        {
                            Money.Text = tabs[7];
                            Garage_Theme.SelectedIndex = int.Parse(tabs[464]);
                            //480 is the first string for crew member, while 481 is a pointer to its car
                            Selected_Player_Car = int.Parse(tabs[1]);
                            Crew_1_ID = int.Parse(tabs[480]); //crew memeber hash
                            Crew_1_Car_Slot = byte.Parse(tabs[481]); //car slot position
                            Crew_2_ID = int.Parse(tabs[482]); //crew memeber hash
                            Crew_2_Car_Slot = byte.Parse(tabs[483]); //car slot position
                            Crew_3_ID = int.Parse(tabs[484]); //crew memeber hash
                            Crew_3_Car_Slot = byte.Parse(tabs[485]); //car slot position
                            Crew_Name.Text = tabs[486];
                            Crew_Name.Text = Crew_Name.Text.Replace("\"", "");
                            break;
                        }
                    case "3391526480:":
                        {
                            // Unlocks
                            /*Array_Count_Unlocks = tabs[1];
                            Array_Unlockables = new string[uint.Parse(Array_Count_Unlocks)];
                            for (int i = 0; i < uint.Parse(Array_Count_Unlocks); i++)
                            {
                                //Array_Unlockabes[i] = tabs[1 + 3];
                            } */
                            break;
                        }
                    case "2268361667:": //Rewards
                        {
                            /*for (int i = 1; i < Int32.Parse(tabs[76]) * 2; i += 2)
                            {

                                tabs[76 + i] = "1";
                            } */
                            break;
                        }
                   
                            case "3061804230:":
                        {
                            //int Strike_Markers = 0;
                           // int Get_Out_Of_Jail_Markers = 0;
                            if (0 < Int32.Parse(tabs[1]))
                            {
                                for (int i = 2; i < Int32.Parse(tabs[1])+2; i++)
                                {
                                    switch (tabs[i])
                                    {
                                        case "10":
                                            {
                                                if (Get_Out_Of_Jail_Markers.Value + 1 <= Get_Out_Of_Jail_Markers.Maximum)
                                                {
                                                    Get_Out_Of_Jail_Markers.Value++;
                                                }
                                                break;
                                            }
                                        case "13":
                                            {
                                                if (Strike_Markers.Value + 1 <= Strike_Markers.Maximum)
                                                {
                                                    Strike_Markers.Value++;
                                                }
                                                break;
                                            }
                                    }
                                }
                            }
                            //inPound markets are value of 13 and Get out of Jail is 10
                            break;
                        }
                                
                        
                }
            }
        }


        
       
            public static string Edit_Player_Name(string[] Career, string Player_Name, ref string file_path)
        {
            string rawName = Career[1];
            char[] charsToStrip = { '\"', '\\', '\t', '\0', ' ' };
            string cleanOldName = rawName.Trim(charsToStrip);

            if (!string.IsNullOrEmpty(file_path) && cleanOldName != Player_Name)
            {
                // 1. Generate the NEW path string
                string newFilePath = file_path.Replace(cleanOldName, Player_Name);

                // 2. Get the directory part of the new path
                // e.g., "C:\Saves\Razor\Alias" -> "C:\Saves\NewName\"
                string newDirectory = Path.GetDirectoryName(newFilePath);

                try
                {
                    // 3. Create the folder if it doesn't exist
                    if (!string.IsNullOrEmpty(newDirectory) && !Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }

                    // Update the reference so the rest of your app knows where the file is now
                    file_path = newFilePath;
                }
                catch (Exception ex)
                {
                    // Handle permissions issues (e.g., trying to write to Program Files)
                    Console.WriteLine($"Error creating directory: {ex.Message}");
                }
            }

            // Update the actual data array for the save file
            Career[1] = Player_Name;
            return string.Join("\t", Career);
        }


        public static string varable_unlocks(string[] Data_Table_Index_List, bool[] CBA)
        {
            List<string> tabList = Data_Table_Index_List.ToList();
            List<string> Unlocks_List = new List<string>();

            if (CBA[0] == true)
            {
                for (int p = 0; p < Beta_Cars.Length; p++)
                {
                    Unlocks_List.Add(((int)Helper_Functions.Bin_Hash(Beta_Cars[p])).ToString());
                }
            }
            if (CBA[1] == true)
            {
                for (int p = 0; p < Stock_Cars.Length; p++)
                {
                    Unlocks_List.Add(((int)Helper_Functions.Bin_Hash(Stock_Cars[p])).ToString());
                }

            }
            if (CBA[2]== true)
            {
                for (int p = 0; p < Bonus_Cars.Length; p++)
                {
                    Unlocks_List.Add(((int)Helper_Functions.Bin_Hash(Bonus_Cars[p])).ToString());
                }
            }
            if (CBA[3] == true)
            {
                for (int p = 0; p < Custom_Cars.Length; p++)
                {
                    Unlocks_List.Add(((int)Helper_Functions.Bin_Hash(Custom_Cars[p])).ToString());
                }
            }
            if (CBA[4]== true)
            {
                for (int p = 0; p < copNames.Length; p++)
                {
                    Unlocks_List.Add(((int)Helper_Functions.Bin_Hash(copNames[p])).ToString());
                }
            }
            if (CBA[5] == true)
            {
                for (int p = 0; p < trafficNames.Length; p++)
                {
                    Unlocks_List.Add(((int)Helper_Functions.Bin_Hash(trafficNames[p])).ToString());
                }
            }
            if (CBA[6] == true)
            {
                for (int p = 0; p < Performance_Parts.Length; p++)
                {
                    Unlocks_List.Add(((int)Performance_Parts[p]).ToString());
                }
            }
            if (CBA[7] == true)
            {
                for (int p = 0; p < All_Body_Parts.Length; p++)
                {
                    Unlocks_List.Add(((int)All_Body_Parts[p]).ToString());
                }
            }
            if (CBA[8] == true)
            {
                for (int p = 0; p < All_Visuals_List.Length; p++)
                {
                    Unlocks_List.Add(((int)All_Visuals_List[p]).ToString());
                }
            }
            
              

            List<string> existing = new List<string>();
            for (int i = 5; i < tabList.Count; i += 2)
            {
                existing.Add(tabList[i]);
            }

            // i starts at 5 (first ID). We check until the end of the ACTUAL list.


            if ((((tabList.Count - 5) / 2) + Unlocks_List.Count) < 1000)
            {
                foreach (string id in Unlocks_List)
                {
                    if (!existing.Contains(id))
                    {
                        tabList.Add(id);
                        tabList.Add("1");
                    }
                }
            }
            else
            {
                for (int i = 5; tabList.Count > i;)
                {
                    tabList.RemoveAt(i);
                }
                foreach (string id in Unlocks_List)
                {
                   
                        tabList.Add(id);
                        tabList.Add("1");
                    
                }
            }
            
            

            // If we checked the WHOLE line and 'found' is still false
            int finalCount = (tabList.Count - 5) / 2;
            if (finalCount >= 1000)
            {
                MessageBox.Show("Too Many");
            }
            tabList[1] = finalCount.ToString();
            return string.Join("\t", tabList);
        }
        

        public static string Populate_Unlocked_Cars(string[] Data_Table_Index_List)
        {
            
            List<string> tabList = Data_Table_Index_List.ToList();
            List<string> Car_List = new List<string>();

            for (int p = 0; p < carUnlocks.Length; p++)
            {
                Car_List.Add((((int)Helper_Functions.Bin_Hash(carUnlocks[p])).ToString()));
            }

            List<string> existing = new List<string>();
            for (int i = 5; i < tabList.Count; i += 2)
            {
                existing.Add(tabList[i]);
            }

            // i starts at 5 (first ID). We check until the end of the ACTUAL list.
            foreach (string id in Car_List)
            {
                if (!existing.Contains(id))
                {
                    tabList.Add(id);
                    tabList.Add("1");
                }
            }

            // If we checked the WHOLE line and 'found' is still false
            int finalCount = (tabList.Count - 5) / 2;
            tabList[1] = finalCount.ToString();
            return string.Join("\t", tabList);
        }
        public static string Populate_Part_Unlocks(string[] Data_Table_Index_List)
        {
            List<string> tabList = Data_Table_Index_List.ToList();
            List<string> Master_List = new List<string>();

            for (int p = 0; p < Parts_Master_List.Length; p++)
            {
                Master_List.Add((((int)Parts_Master_List[p])).ToString());
            }

            List<string> existing = new List<string>();
            for (int i = 5; i < tabList.Count; i += 2)
            {
                existing.Add(tabList[i]);
            }

            // i starts at 5 (first ID). We check until the end of the ACTUAL list.
            foreach (string id in Master_List)
            {
                if (!existing.Contains(id))
                {
                    tabList.Add(id);
                    tabList.Add("1");
                }
            }

            // If we checked the WHOLE line and 'found' is still false
            int finalCount = (tabList.Count - 5) / 2;
            tabList[1] = finalCount.ToString();
            return string.Join("\t", tabList);
        }
        public static void Convert_Data_Table_PC_XBOX(ref byte[] Data, bool Xbox)
        {
            string Data_String;
            Data_String = Encoding.ASCII.GetString(Data);
            // 1. Convert binary to string
            string rawString = Encoding.Default.GetString(Data);
            List<string> Data_Table = Data_String.Split('\n').ToList();

            //string[] Data_Table = Data_String.Split('\n'); //Creates new lines instead of being all on 1 line
            for (int j = 0; j < Data_Table.Count; j++)
            {
                string[] Data_Table_Index_List = Data_Table[j].Split('\t');
                string Data_Table_Index_Title = Data_Table_Index_List[0]; // Remove the colon from the label
                switch (Data_Table_Index_Title)
                {
                    case "908757060:":
                        {

                            if (!Data_Table[j + 1].Contains("957703527:") && Xbox == false)
                            {
                                string labelToInject = "\n957703527:\t0\t0\t1\t200\t1\t30\t1\t208\t1\t44\t1\t203\t0\t0\t1\t205\t0\t0\t1\t57\t0\t0\t1\t45\t1\t34\t1\t56\t0\t0\t1\t29\t0\t0\t1\t42\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t1\t19\t0\t0\t1\t157\t0\t0\t0";

                                // Keep the original 908757060 line, append a newline, then append the injected data
                                Data_Table[j] = string.Join("\t", Data_Table_Index_List) + labelToInject;
                            }
                            break;
                        }
                    case "957703527:":
                        {
                            if (Xbox == true)
                            {
                                Data_Table.RemoveAt(j);
                            }
                            //MessageBox.Show("PC Save File");
                            break;
                        }
                }


            }
            string finalString = string.Join("\n", Data_Table);

            Data = Encoding.ASCII.GetBytes(finalString);

            
        }
        
        public static void Breaking_Down_Data(ref byte[] Data, ref TextBox Money, ref TextBox Career_Name, ref TextBox Crew_Name, bool Xbox, bool unlockPerformance,bool unlockVisuals,bool unlockRewardCards,bool unlockAutosculpt, bool showCrew, bool stockCars, bool bonusCars, bool customCars, bool Copcars, bool TrafficCars, bool Betacars, bool completeMap, bool mazdaDealer, NumericUpDown Strike_Markers, NumericUpDown Get_Out_Of_Jail_Markers, ComboBox Garage_Theme, CheckBox Skip_Tut_CB)
        {
            string Data_String;
            Data_String = Encoding.ASCII.GetString(Data);
            // 1. Convert binary to string
            string rawString = Encoding.Default.GetString(Data);
            List<string> Data_Table = Data_String.Split('\n').ToList();
            
            //string[] Data_Table = Data_String.Split('\n'); //Creates new lines instead of being all on 1 line
            for (int j = 0; j < Data_Table.Count; j++)
            {
                string[] Data_Table_Index_List = Data_Table[j].Split('\t');
                string Data_Table_Index_Title = Data_Table_Index_List[0]; // Remove the colon from the label
                switch (Data_Table_Index_Title)
                {
                    case "908757060:":
                        {
                           
                            if (!Data_Table[j+1].Contains("957703527:") && Xbox == false)
                            {
                                string labelToInject = "\n957703527:\t0\t0\t1\t200\t1\t30\t1\t208\t1\t44\t1\t203\t0\t0\t1\t205\t0\t0\t1\t57\t0\t0\t1\t45\t1\t34\t1\t56\t0\t0\t1\t29\t0\t0\t1\t42\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t1\t19\t0\t0\t1\t157\t0\t0\t0";

                                // Keep the original 908757060 line, append a newline, then append the injected data
                                Data_Table[j] = string.Join("\t", Data_Table_Index_List) + labelToInject;
                            }
                            break;
                        }
                    case "957703527:":
                    {
                            if (Xbox == true)
                            {
                                Data_Table.RemoveAt(j);
                            }
                            //MessageBox.Show("PC Save File");
                            break;
                     }
                    
                    case "3391526480:": // Unlocks
                        {
                           
                            string current = string.Join("\t", Data_Table_Index_List);
                            bool[] CBA =
                            {
                                Betacars, stockCars, bonusCars, customCars,Copcars,TrafficCars,unlockPerformance,unlockAutosculpt,unlockVisuals
                            };
                            
                                current = varable_unlocks(current.Split('\t'), CBA);
                            
                            
                            
                            Data_Table[j] = string.Join("\t", current);
                            break;
                        }
                    case "2287685084:":
                        {
                            // Money
                            //Money = Data_Table_Index_List[7];
                            //Data_Table_Index_List[1] = ""; //Car Slot Id For Main Car
                            if (Skip_Tut_CB.Checked)
                            {
                                Data_Table_Index_List[5] = "3";
                            }
                            Data_Table_Index_List[7] = Money.Text; //money
                            if (completeMap == true)
                            {
                                Data_Table_Index_List[8] = "6075"; //Races available
                            }
                            Data_Table_Index_List[464] = Garage_Theme.SelectedIndex.ToString();
                            Data_Table_Index_List[486] = Crew_Name.Text; //Crew Name
                            Data_Table[j] = string.Join("\t", Data_Table_Index_List);
                            break;
                        }
                    case "3061804230:":
                        {
                            string[] Markers = new string[(int)(Strike_Markers.Value + Get_Out_Of_Jail_Markers.Value + 2)];
                            Markers[0] = "3061804230:";
                            Markers[1] = (Strike_Markers.Value + Get_Out_Of_Jail_Markers.Value).ToString();
                            int Strike_M = (int)Strike_Markers.Value;
                            int GOOJ = (int)Get_Out_Of_Jail_Markers.Value;
                            
                            for (int i = 0; i < Markers.Length;)
                            {
                                if (Strike_M > 0)
                                {
                                    Markers[i + 2] = "13";
                                    Strike_M--;
                                    i++;
                                }
                                
                                else if (GOOJ > 0)
                                {
                                    Markers[i + 2] = "10";
                                    GOOJ--;
                                    i++;
                                }
                                else
                                {
                                    i++;
                                }

                            }


                            Data_Table[j] = string.Join("\t", Markers);
                            // Data_Table_Index_List[1]
                            //inPound markets are value of 13 and Get out of Jail is 10
                            break;
                        }
                    case "831388323:":
                        {
                            //gameplay stats
                            break;
                        }
                    case "841929775:":
                        {
                            /*Career_Name.Text = Career_Name.Text.Insert(0,"\"");
                            Career_Name.Text = Career_Name.Text.Insert(Career_Name.Text.Length, "\""); */
                            Data_Table_Index_List[1] = Career_Name.Text;
                            Data_Table[j] = string.Join("\t", Data_Table_Index_List);

                            // Career_Name.Remove(Career_Name.Length - 1);
                            // Data_Table[j] = Edit_Player_Name(Data_Table_Index_List, New_Player_Name, );
                            break;
                        }
                    case "2268361667:": //Rewards
                        {
                            if (unlockRewardCards == true)
                            {

                                int Reward_Card_Length = Int32.Parse(Data_Table_Index_List[76]) * 2;
                                for (int i = 1; i < Reward_Card_Length; i += 2)
                                {

                                    Data_Table_Index_List[76 + i] = "1";
                                }

                                int Online_Reward_Card_Length = Int32.Parse(Data_Table_Index_List[338]) * 2;
                                for (int p = 1; p < Online_Reward_Card_Length; p += 2)
                                {
                                    Data_Table_Index_List[338 + p] = "1";
                                }
                            }

                            Data_Table[j] = string.Join("\t", Data_Table_Index_List); 
                            break;
                        }

                }
                
                
            }
            string finalString = string.Join("\n", Data_Table);
            
            Data = Encoding.ASCII.GetBytes(finalString);

            //File.WriteAllText("C:\\Users\\Logic\\Documents\\Xenia\\content\\454107EC\\00000001\\ALIAS_1551.wr", finalString);
        }
        public static void Write_Data_Table(ref byte[] Data, bool Unlock_All_Normal_Reward_Cards, bool Unlock_All_Online_Reward_Cards, string Update_Money, string player_Name)
        {
            
            string test;
            test = Encoding.ASCII.GetString(Data);
            string[] lines = test.Split('\n');
            for (int j = 0; j < lines.Length; j++)
            {
                string[] tabs = lines[j].Split('\t');
                string label = tabs[0]; // Remove the colon from the label

                switch (label)
                {
                    case "841929775:": // Names
                        tabs[1] = player_Name;
                        lines[j] = string.Join("\t", tabs);
                        break;
                    case "2287685084:": // Money
                        tabs[7] = Update_Money;
                        lines[j] = string.Join("\t", tabs);
                        break; 
                    case "3391526480:": // Unlocks
                        {
                            List<string> tabList = tabs.ToList();

                            for (int p = 0; p < Parts_Master_List.Length; p++)
                            {
                                bool found = false;
                                string searchId = ((int)Parts_Master_List[p]).ToString();

                                // i starts at 5 (first ID). We check until the end of the ACTUAL list.
                                for (int i = 5; i < tabList.Count; i += 2)
                                {
                                    if (tabList[i] == searchId)
                                    {
                                        found = true;
                                        break; // STOP searching this part immediately.
                                    }
                                }

                                // If we checked the WHOLE line and 'found' is still false
                                if (!found)
                                {
                                    tabList.Add(searchId);
                                    tabList.Add("1");
                                }
                            }

                            for (int c = 0; c < carUnlocks.Length; c++)
                            {
                                bool found = false;
                                string searchId = ((int)Helper_Functions.Bin_Hash(carUnlocks[c])).ToString();

                                // i starts at 5 (first ID). We check until the end of the ACTUAL list.
                                for (int i = 5; i < tabList.Count; i += 2)
                                {
                                    if (tabList[i] == searchId)
                                    {
                                        found = true;
                                        break; // STOP searching this part immediately.
                                    }
                                }

                                // If we checked the WHOLE line and 'found' is still false
                                if (!found)
                                {
                                    tabList.Add(searchId);
                                    tabList.Add("1");
                                }
                            }

                            // Recalculate the count based on actual pairs: (Total - 5 header tabs) / 2
                            int finalCount = (tabList.Count - 5) / 2;
                            tabList[1] = finalCount.ToString();

                            lines[j] = string.Join("\t", tabList);
                            break;
                        }
                
                    case "2268361667:": //Rewards
                        {
                            if (Unlock_All_Normal_Reward_Cards)
                            {
                                int Reward_Card_Length = Int32.Parse(tabs[76]) * 2;
                                for (int i = 1; i < Reward_Card_Length; i += 2)
                                {

                                    tabs[76 + i] = "1";
                                }
                            }
                            if (Unlock_All_Online_Reward_Cards)
                            {
                                int Online_Reward_Card_Length = Int32.Parse(tabs[338]) * 2;
                                for (int p = 1; p < Online_Reward_Card_Length; p += 2)
                                {
                                    tabs[338 + p] = "1";
                                }
                            }

                            lines[j] = string.Join("\t", tabs);
                            break;
                        }
                }
                
            }
            string finalString = string.Join("\n", lines);
            Data = Encoding.ASCII.GetBytes(finalString);

        }

        public static string[] challengeArray = new string[]
{
    "cs.1.1", "cs.1.2", "cs.1.3", "cs.2.1", "cs.2.2", "cs.2.3", "cs.3.1", "cs.3.2", "cs.3.3",
    "cs.13.1", "cs.13.2", "cs.13.3", "cs.14.4", "cs.14.2", "cs.14.3", "cs.6.1", "cs.6.2", "cs.6.3",
    "cs.7.1", "cs.7.2", "cs.7.3", "cs.8.1", "cs.8.2", "cs.8.3", "cs.9.1", "cs.9.2", "cs.9.3",
    "cs.10.1", "cs.10.2", "cs.10.3", "cs.11.1", "cs.11.2", "cs.11.3", "cs.12.1", "cs.12.2", "cs.12.3",
    "ce.4.1", "ce.4.3", "ce.4.2", "ce.1.1",  "ce.1.2",  "ce.1.3", "ce.1.4",  "ce.1.5",  "ce.1.6", "ce.5.1", "ce.5.2", "ce.3.1", "ce.15.2","ce.15.3" //, "cs.15.1", "ce.15.2", "ce.15.3" 
};

        public static string[] challengeArray1 = new string[]
        {
            
        };

        public static void Unlock_All_Challenge_Series(ref byte[] Data, bool Xbox)
        {
            for (int i = 0; i < challengeArray.Length; i++)
            {
                int Pos = Helper_Functions.Grab_Position_From_Anchor(Data, Xbox);
                while (Helper_Functions.ReadUInt32(Data, Pos, Xbox) != Helper_Functions.VLT_Hash(challengeArray[i]))
                {
                    Pos += 4;
                }
                Helper_Functions.WriteUInt32(Data,Pos + 4, Helper_Functions.ReadUInt32(Data,Pos + 4, Xbox) | 4,Xbox);

            }
        }
    }
}
