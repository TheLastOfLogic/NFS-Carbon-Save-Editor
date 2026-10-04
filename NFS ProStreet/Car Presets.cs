using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA_MD5_hasher.NFS_ProStreet
{
    public static class Car_Presets
    {

        public class RacerProfile
        {
            public string Tag { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string[] CarModel => AssignedRaces
            .Where(race => presetCarMap.ContainsKey(race))
            .Select(race => presetCarMap[race])
            .Distinct() // Removes duplicates if multiple races use the same car
            .ToArray();
            public string[] AssignedRaces { get; set; } = Array.Empty<string>();
        }


        

        public static readonly List<RacerProfile> Racers = new()
{

    new RacerProfile
    {
        // Base Racers
        Tag = "RACERNAME_000", Name = "Alex Hutton", /*CarModel = new []{ "cobaltss", "gti", "s3", "challenger71", "mustangshlbyo", "gto65" }, */ AssignedRaces = new []{ "ch_t1_ptl_drag_mustgt", "ch_t1_ptl_grip_civichb", "opp_0_drag", "opp_0_drift", "opp_0_grip", "opp_0_sc" }
    },
    new RacerProfile
    {
        Tag = "RACERNAME_001", Name = "Ken Burney", /*CarModel = new []{ "civichb","gti", "gti", "camaro", "challenger71", "mustangshlbyo" }, */AssignedRaces = new []{ "ch_t1_ptl_drag_civichb", "ch_t1_ptl_grip_civichb", "opp_1_drag", "opp_1_drift", "opp_1_grip", "opp_1_sc" }
    },

    new RacerProfile
    {
        Tag = "RACERNAME_002", Name = "Paul Ko", AssignedRaces = new[] {
    "ch_t1_ptl_drag_mustgt", "ch_t1_ptl_grip_civichb", "opp_2_drag", "opp_2_drift", "opp_2_grip", "opp_2_sc"}
    },
    new RacerProfile
{
    Tag = "RACERNAME_003", Name = "Don Berry", AssignedRaces = new string[] { "ch_t1_ptl_drag_civichb",
    "ch_t1_ptl_grip_civichb",
    "opp_3_drag",
    "opp_3_drift",
    "opp_3_grip",
    "opp_3_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_004", Name = "Pete Carter", AssignedRaces = new string[] {"ch_t1_ptl_drag_mustgt",
    "ch_t1_ptl_grip_civichb",
    "opp_4_drag",
    "opp_4_drift",
    "opp_4_grip",
    "opp_4_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_005", Name = "Eddy Spencer", AssignedRaces = new string[] { "ch_t1_ptl_drag_civichb",
    "ch_t1_ptl_grip_civichb",
    "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_350z",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_is350",
    "ch_t1_willow_grip_is350",
    "opp_5_drag",
    "opp_5_drift",
    "opp_5_grip",
    "opp_5_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_006", Name = "Bill Newman", AssignedRaces = new string[] {"ch_t1_ptl_drag_mustgt",
    "ch_t1_ptl_grip_civichb",
    "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_gti",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_chevelle",
    "ch_t1_willow_grip_is350",
    "opp_6_drag",
    "opp_6_drift",
    "opp_6_grip",
    "opp_6_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_007", Name = "Will Jackson", AssignedRaces = new string[] {"ch_t1_ptl_drag_civichb",
    "ch_t1_ptl_grip_civichb",
    "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_350z",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_is350",
    "ch_t1_willow_grip_is350",
    "opp_7_drag",
    "opp_7_drift",
    "opp_7_grip",
    "opp_7_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_008", Name = "Carl Sanner", AssignedRaces = new string[] { "ch_t1_ptl_drag_mustgt",
    "ch_t1_ptl_grip_civichb",
    "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_gti",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_chevelle",
    "ch_t1_willow_grip_is350",
    "opp_8_drag",
    "opp_8_drift",
    "opp_8_grip",
    "opp_8_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_009", Name = "Dale Bennett", AssignedRaces = new string[] { "ch_t1_ptl_drag_civichb",
    "ch_t1_ptl_grip_civichb",
    "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_350z",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_is350",
    "ch_t1_willow_grip_is350",
    "opp_9_drag",
    "opp_9_drift",
    "opp_9_grip",
    "opp_9_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_010", Name = "Felix Tang", AssignedRaces = new string[] { "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_gti",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_chevelle",
    "ch_t1_willow_grip_is350",
    "opp_10_drag",
    "opp_10_drift",
    "opp_10_grip",
    "opp_10_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_011", Name = "Pedro Wilson", AssignedRaces = new string[] {"ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_350z",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_is350",
    "ch_t1_willow_grip_is350",
    "opp_11_drag",
    "opp_11_drift",
    "opp_11_grip",
    "opp_11_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_012", Name = "Wade Jackson", AssignedRaces = new string[] { "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_gti",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_chevelle",
    "ch_t1_willow_grip_is350",
    "opp_12_drag",
    "opp_12_drift",
    "opp_12_grip",
    "opp_12_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_013", Name = "Angelo Rowley", AssignedRaces = new string[] { "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_350z",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_is350",
    "ch_t1_willow_grip_is350",
    "opp_13_drag",
    "opp_13_drift",
    "opp_13_grip",
    "opp_13_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_014", Name = "Adrian Reed", AssignedRaces = new string[] { "ch_t1_tx_drag_gti",
    "ch_t1_tx_drift_350z",
    "ch_t1_tx_grip_gti",
    "ch_t1_willow_drag_chevelle",
    "ch_t1_willow_drift_chevelle",
    "ch_t1_willow_grip_is350",
    "opp_14_drag",
    "opp_14_drift",
    "opp_14_grip",
    "opp_14_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_015", Name = "Christopher Jones", AssignedRaces = new string[] { "No Races Found"}
},
new RacerProfile
{
    Tag = "RACERNAME_016", Name = "Blaine Cook", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_017", Name = "Chad Byers", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_018", Name = "Travis Bratton", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_019", Name = "Ron Chen", AssignedRaces = new string[] { "No Races Found"}
},
new RacerProfile
{
    Tag = "RACERNAME_020", Name = "Masahide Omura", AssignedRaces = new string[] { "ch_t2_mond_drift_gto",
    "ch_t2_mond_grip_gto",
    "opp_20_drag",
    "opp_20_drift",
    "opp_20_grip",
    "opp_20_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_021", Name = "Kazutoshi Kawakami", AssignedRaces = new string[] { "ch_t2_mond_drift_g35",
    "ch_t2_mond_grip_gto",
    "opp_21_drag",
    "opp_21_drift",
    "opp_21_grip",
    "opp_21_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_022", Name = "Ryoma Shibasawa", AssignedRaces = new string[] { "ch_t2_mond_drift_gto",
    "ch_t2_mond_grip_gto",
    "opp_22_drag",
    "opp_22_drift",
    "opp_22_grip",
    "opp_22_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_023", Name = "Shinji Takasu", AssignedRaces = new string[] { "opp_23_drag",
    "opp_23_drift",
    "opp_23_grip",
    "opp_23_sc",
    "ch_t2_mond_drift_g35",
    "ch_t2_mond_grip_gto"}
},
new RacerProfile
{
    Tag = "RACERNAME_024", Name = "Ukyo Ihara", AssignedRaces = new string[] { "ch_t2_mond_drift_gto",
    "ch_t2_mond_grip_gto",
    "opp_24_drag",
    "opp_24_drift",
    "opp_24_grip",
    "opp_24_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_025", Name = "Masato Kihara", AssignedRaces = new string[] { "opp_25_drag",
    "opp_25_drift",
    "opp_25_grip",
    "opp_25_sc",
    "ch_t2_autop_drift_solstice",
    "ch_t2_autop_grip_s15",
    "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_bmwm3",
    "ch_t2_mond_drift_g35",
    "ch_t2_mond_grip_gto"}
},
new RacerProfile
{
    Tag = "RACERNAME_026", Name = "Sadatake Ueshima", AssignedRaces = new string[] { "ch_t2_mond_drift_gto",
    "ch_t2_mond_grip_gto",
    "opp_26_drag",
    "opp_26_drift",
    "opp_26_grip",
    "opp_26_sc",
    "ch_t2_autop_drift_s15",
    "ch_t2_autop_grip_s15",
    "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_supra"}
},
new RacerProfile
{
    Tag = "RACERNAME_027", Name = "Atshushi Muraguchi", AssignedRaces = new string[] { "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_bmwm3",
    "ch_t2_mond_drift_g35",
    "ch_t2_mond_grip_gto",
    "opp_27_drag",
    "opp_27_drift",
    "opp_27_grip",
    "opp_27_sc",
    "ch_t2_autop_drift_solstice",
    "ch_t2_autop_grip_s15" }
},
new RacerProfile
{
    Tag = "RACERNAME_028", Name = "Shinji Mori", AssignedRaces = new string[] { "ch_t2_autop_drift_s15",
    "ch_t2_autop_grip_s15",
    "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_supra",
    "ch_t2_mond_drift_gto",
    "ch_t2_mond_grip_gto",
    "opp_28_drag",
    "opp_28_drift",
    "opp_28_grip",
    "opp_28_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_029", Name = "Kaneko Hiroyori", AssignedRaces = new string[] { "opp_29_drag",
    "opp_29_drift",
    "opp_29_grip",
    "opp_29_sc",
    "ch_t2_autop_drift_solstice",
    "ch_t2_autop_grip_s15",
    "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_bmwm3",
    "ch_t2_mond_drift_g35",
    "ch_t2_mond_grip_gto"}
},
new RacerProfile
{
    Tag = "RACERNAME_030", Name = "Tomonori Uetake", AssignedRaces = new string[] { "opp_30_drag",
    "opp_30_drift",
    "opp_30_grip",
    "opp_30_sc",
    "ch_t2_autop_drift_s15",
    "ch_t2_autop_grip_s15",
    "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_supra" }
},
new RacerProfile
{
    Tag = "RACERNAME_031", Name = "Kohji Yamagata", AssignedRaces = new string[] { "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_bmwm3",
    "opp_31_drag",
    "opp_31_drift",
    "opp_31_grip",
    "opp_31_sc",
    "ch_t2_autop_drift_solstice",
    "ch_t2_autop_grip_s15"}
},
new RacerProfile
{
    Tag = "RACERNAME_032", Name = "Kazu Yoshida", AssignedRaces = new string[] { "ch_t2_autop_drift_s15",
    "ch_t2_autop_grip_s15",
    "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_supra",
    "opp_32_drag",
    "opp_32_drift",
    "opp_32_grip",
    "opp_32_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_033", Name = "Makoto Yoshizawa", AssignedRaces = new string[] { "opp_33_drag",
    "opp_33_drift",
    "opp_33_grip",
    "opp_33_sc",
    "ch_t2_autop_drift_solstice",
    "ch_t2_autop_grip_s15",
    "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_supra" }
},
new RacerProfile
{
    Tag = "RACERNAME_034", Name = "Yoshiaki Kawakami", AssignedRaces = new string[] { "ch_t2_ebisu_drift_supra",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_ebisu_sc_supra",
    "opp_34_drag",
    "opp_34_drift",
    "opp_34_grip",
    "opp_34_sc",
    "ch_t2_autop_drift_s15",
    "ch_t2_autop_grip_s15" }
},
new RacerProfile
{
    Tag = "RACERNAME_035", Name = "Conrad Miller", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_036", Name = "Fred Watkins", AssignedRaces = new string[] { "No Races Found"}
},
new RacerProfile
{
    Tag = "RACERNAME_037", Name = "Diego Wolfe", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_038", Name = "Marcel Porter", AssignedRaces = new string[] { "No Races Found"}
},
new RacerProfile
{
    Tag = "RACERNAME_039", Name = "Jonathan Evans", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_040", Name = "Takuya Kawayama", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_041", Name = "Satoshi Hosokaya", AssignedRaces = new string[] { "opp_41_drag",
    "opp_41_drift",
    "opp_41_grip",
    "opp_41_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_042", Name = "Mitsuharu Tanaka", AssignedRaces = new string[] { "opp_42_drag",
    "opp_42_drift",
    "opp_42_grip",
    "opp_42_sc",
    "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_skyline",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_cayman",
    "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_rs4"}
},
new RacerProfile
{
    Tag = "RACERNAME_043", Name = "Naoki Yoshihara", AssignedRaces = new string[] {"opp_43_drag",
    "opp_43_drift",
    "opp_43_grip",
    "opp_43_sc",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_nsx" }
},
new RacerProfile
{
    Tag = "RACERNAME_044", Name = "Hiroaki Terasawa", AssignedRaces = new string[] { "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_cayman",
    "opp_44_drag",
    "opp_44_drift",
    "opp_44_grip",
    "opp_44_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_045", Name = "Munehiko Kawaguchi", AssignedRaces = new string[] { "opp_45_drag",
    "opp_45_drift",
    "opp_45_grip",
    "opp_45_sc",
    "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_viper",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_nsx",
    "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_z06"}
},
new RacerProfile
{
    Tag = "RACERNAME_046", Name = "Mitsuhide Nakamura", AssignedRaces = new string[] { "opp_46_drag",
    "opp_46_drift",
    "opp_46_grip",
    "opp_46_sc",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_cayman"}
},
new RacerProfile
{
    Tag = "RACERNAME_047", Name = "Yoshio Sato", AssignedRaces = new string[] {"ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_nsx",
    "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_z06",
    "opp_47_drag",
    "opp_47_drift",
    "opp_47_grip",
    "opp_47_sc",
    "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_viper" }
},
new RacerProfile
{
    Tag = "RACERNAME_048", Name = "Charlie Heyman", AssignedRaces = new string[] { "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_skyline",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_cayman",
    "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_rs4",
    "opp_48_drag",
    "opp_48_drift",
    "opp_48_grip",
    "opp_48_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_049", Name = "Colby Canham", AssignedRaces = new string[] { "opp_49_drag",
    "opp_49_drift",
    "opp_49_grip",
    "opp_49_sc",
    "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_viper",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_nsx",
    "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_z06"}
},
new RacerProfile
{
    Tag = "RACERNAME_050", Name = "Brandon Tennant ^", AssignedRaces = new string[] { "opp_50_drag",
    "opp_50_drift",
    "opp_50_grip",
    "opp_50_sc",
    "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_skyline",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_cayman",
    "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_rs4" }
},
new RacerProfile
{
    Tag = "RACERNAME_051", Name = "Perry Prescott", AssignedRaces = new string[] {"ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_z06",
    "opp_51_drag",
    "opp_51_drift",
    "opp_51_grip",
    "opp_51_sc",
    "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_viper",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_infineon_grip_nsx" }
},
new RacerProfile
{
    Tag = "RACERNAME_052", Name = "Oliver Armitage", AssignedRaces = new string[] { "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_rs4",
    "opp_52_drag",
    "opp_52_drift",
    "opp_52_grip",
    "opp_52_sc",
    "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_skyline"}
},
new RacerProfile
{
    Tag = "RACERNAME_053", Name = "Don Braun", AssignedRaces = new string[] {"ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_viper",
    "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_z06",
    "opp_53_drag",
    "opp_53_drift",
    "opp_53_grip",
    "opp_53_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_054", Name = "Seb Crawford", AssignedRaces = new string[] {"opp_54_drag",
    "opp_54_drift",
    "opp_54_grip",
    "opp_54_sc",
    "ch_t3_autob_drift_viper",
    "ch_t3_autob_grip_skyline",
    "ch_t3_autob_sc_skyline",
    "ch_t3_nevada_drag_z06",
    "ch_t3_nevada_drift_z06",
    "ch_t3_nevada_grip_rs4",
    "ch_t3_nevada_sc_rs4" }
},
new RacerProfile
{
    Tag = "RACERNAME_055", Name = "Tyron Bryan", AssignedRaces = new string[] { "No Racers Found"}
},
new RacerProfile
{
    Tag = "RACERNAME_056", Name = "Stuart Mitchell", AssignedRaces = new string[] { "No Racers Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_057", Name = "Kyle Easter", AssignedRaces = new string[] { "No Racers Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_058", Name = "Scott East", AssignedRaces = new string[] { "No Racers Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_059", Name = "Rory Taggart", AssignedRaces = new string[] { "No Racers Found" }
},
new RacerProfile
{
    Tag = "RACERNAME_060", Name = "Mike Lineman", AssignedRaces = new string[] {"hd_opp_1_drag",
    "hd_opp_1_drift",
    "hd_opp_1_grip",
    "hd_opp_1_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_061", Name = "Matt Pritchard", AssignedRaces = new string[] { "hd_opp_2_drag",
    "hd_opp_2_drift",
    "hd_opp_2_grip",
    "hd_opp_2_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_062", Name = "Karl Losey", AssignedRaces = new string[] { "hd_opp_3_drag",
    "hd_opp_3_drift",
    "hd_opp_3_grip",
    "hd_opp_3_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_063", Name = "Ben Haverman", AssignedRaces = new string[] {"hd_opp_4_drag",
    "hd_opp_4_drift",
    "hd_opp_4_grip",
    "hd_opp_4_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_064", Name = "Filip Douglas", AssignedRaces = new string[] {"hd_opp_5_drag",
    "hd_opp_5_drift",
    "hd_opp_5_grip",
    "hd_opp_5_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_065", Name = "Marcel Buddenseik", AssignedRaces = new string[] {"hd_opp_6_drag",
    "hd_opp_6_drift",
    "hd_opp_6_grip",
    "hd_opp_6_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_066", Name = "Chet Higgens", AssignedRaces = new string[] {"hd_opp_7_drag",
    "hd_opp_7_drift",
    "hd_opp_7_grip",
    "hd_opp_7_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_067", Name = "Klaus Steele", AssignedRaces = new string[] {"hd_opp_8_drag",
    "hd_opp_8_drift",
    "hd_opp_8_grip",
    "hd_opp_8_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_068", Name = "Gustavo Demetrius", AssignedRaces = new string[] {"hd_opp_9_drag",
    "hd_opp_9_drift",
    "hd_opp_9_grip",
    "hd_opp_9_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_069", Name = "Dominik Wilkins", AssignedRaces = new string[] { "hd_opp_10_drag",
    "hd_opp_10_drift",
    "hd_opp_10_grip",
    "hd_opp_10_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_070", Name = "Charlie Gaskins", AssignedRaces = new string[] {"hd_opp_11_drag",
    "hd_opp_11_drift",
    "hd_opp_11_grip",
    "hd_opp_11_sc" /* yes this one is apart of the race,
    "hd_opp_12_drag" */ }
},
new RacerProfile
{
    Tag = "RACERNAME_071", Name = "Bill Tireman", AssignedRaces = new string[] {"hd_opp_12_drag",
    "hd_opp_12_drift",
    "hd_opp_12_grip",
    "hd_opp_12_sc" }
},
new RacerProfile
{
    Tag = "RACERNAME_072", Name = "Al Gregg", AssignedRaces = new string[] { "hd_opp_13_drag",
    "hd_opp_13_drift",
    "hd_opp_13_grip",
    "hd_opp_13_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_073", Name = "Rob Chase", AssignedRaces = new string[] { "hd_opp_14_drag",
    "hd_opp_14_drift",
    "hd_opp_14_grip",
    "hd_opp_14_sc"}
},
new RacerProfile
{
    Tag = "RACERNAME_074", Name = "Bruno Hardy", AssignedRaces = new string[] {"hd_opp_15_drag",
    "hd_opp_15_drift",
    "hd_opp_15_grip",
    "hd_opp_15_sc" }
},

//Booster Opp
new RacerProfile
{
    Tag = "BOOST_RACERNAME_001", Name = "Carey Hill", AssignedRaces = new string[] { "b_opp_1_drag",
    "b_opp_1_drift",
    "b_opp_1_grip",
    "b_opp_1_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_002", Name = "Dustin Elton", AssignedRaces = new string[] { "b_opp_2_drag", "b_opp_2_drift", "b_opp_2_grip", "b_opp_2_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_003", Name = "Josh Fairview", AssignedRaces = new string[] { "b_opp_3_drag",
    "b_opp_3_drift",
    "b_opp_3_grip",
    "b_opp_3_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_004", Name = "David Con", AssignedRaces = new string[] { "b_opp_4_drag",
    "b_opp_4_drift",
    "b_opp_4_grip",
    "b_opp_4_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_005", Name = "Manny Solemn", AssignedRaces = new string[] { "b_opp_5_drag",
    "b_opp_5_drift",
    "b_opp_5_grip",
    "b_opp_5_sc" }
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_006", Name = "Konrad Mull", AssignedRaces = new string[] { "b_opp_6_drag",
    "b_opp_6_drift",
    "b_opp_6_grip",
    "b_opp_6_sc" }
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_007", Name = "Victor Hesh", AssignedRaces = new string[] { "b_opp_7_drift",
    "b_opp_7_grip",
    "b_opp_7_sc",
    //yes this one was found with b_opp_7
    /* "b_opp_8_drag"*/}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_008", Name = "Clayton Mason", AssignedRaces = new string[] { "b_opp_8_drag",
    "b_opp_8_drift",
    "b_opp_8_grip",
    "b_opp_8_sc" }
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_009", Name = "Nikki Swan", AssignedRaces = new string[] { "b_opp_9_drag",
    "b_opp_9_drift",
    "b_opp_9_grip",
    "b_opp_9_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_010", Name = "Jake Winston", AssignedRaces = new string[] { "b_opp_10_drag",
    "b_opp_10_drift",
    "b_opp_10_grip",
    "b_opp_10_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_012", Name = "Edward Hamilton", AssignedRaces = new string[] { "b_opp_12_drag",
    "b_opp_12_drift",
    "b_opp_12_grip",
    "b_opp_12_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_014", Name = "Gary Right", AssignedRaces = new string[] { "b_opp_14_drag",
    "b_opp_14_drift",
    "b_opp_14_grip",
    "b_opp_14_sc" }
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_016", Name = "Vincent Strongarm", AssignedRaces = new string[] { "b_opp_16_drag",
    "b_opp_16_drift",
    "b_opp_16_grip",
    "b_opp_16_sc" }
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_018", Name = "John Laurier", AssignedRaces = new string[] { "b_opp_18_drag",
    "b_opp_18_drift",
    "b_opp_18_grip",
    "b_opp_18_sc" }
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_019", Name = "Jimmy Plant", AssignedRaces = new string[] { "b_opp_19_drag",
    "b_opp_19_drift",
    "b_opp_19_grip",
    "b_opp_19_sc" }
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_020", Name = "Ashley Veer", AssignedRaces = new string[] { "b_opp_20_drag",
    "b_opp_20_drift",
    "b_opp_20_grip",
    "b_opp_20_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_021", Name = "Carl Money", AssignedRaces = new string[] { "b_opp_21_drag",
    "b_opp_21_drift",
    "b_opp_21_grip",
    "b_opp_21_sc"}
},
new RacerProfile
{
    Tag = "BOOST_RACERNAME_022", Name = "Eduardo Williams", AssignedRaces = new string[] { "b_opp_22_drag",
    "b_opp_22_drift",
    "b_opp_22_grip",
    "b_opp_22_sc" }
},

// Elite Racers
new RacerProfile
{
    Tag = "ELITENAME_001", Name = "Mamoru Arakawa", AssignedRaces = new string[] { "elite_opp_1_drag",
    "elite_opp_1_drift",
    "elite_opp_1_grip",
    "elite_opp_1_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_002", Name = "Seiko Makiguchi", AssignedRaces = new string[] {"elite_opp_2_drag",
    "elite_opp_2_drift",
    "elite_opp_2_grip",
    "elite_opp_2_sc" }
},
new RacerProfile
{
    Tag = "ELITENAME_003", Name = "Tsuneo Hamamoto", AssignedRaces = new string[] { "elite_opp_3_drag",
    "elite_opp_3_drift",
    "elite_opp_3_grip",
    "elite_opp_3_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_004", Name = "Takeshi Tatsumi", AssignedRaces = new string[] { "elite_opp_4_drag",
    "elite_opp_4_drift",
    "elite_opp_4_grip",
    "elite_opp_4_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_005", Name = "Ryota Iwahara", AssignedRaces = new string[] { "elite_opp_5_drag",
    "elite_opp_5_drift",
    "elite_opp_5_grip",
    "elite_opp_5_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_006", Name = "Shiheru Mitani", AssignedRaces = new string[] { "No Races Found"}
},
new RacerProfile
{
    Tag = "ELITENAME_007", Name = "Takejiro Okuda", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "ELITENAME_008", Name = "Hide Okui", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "ELITENAME_009", Name = "Masao Hasekura", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "ELITENAME_010", Name = "Minoru Higashiyama", AssignedRaces = new string[] { "No Races Found" }
},
new RacerProfile
{
    Tag = "ELITENAME_011", Name = "Hitoshi Morie", AssignedRaces = new string[] {"elite_opp_11_drag",
    "elite_opp_11_drift",
    "elite_opp_11_grip",
    "elite_opp_11_sc" }
},
new RacerProfile
{
    Tag = "ELITENAME_012", Name = "Nobu Sawayama", AssignedRaces = new string[] {"elite_opp_12_drag",
    "elite_opp_12_drift",
    "elite_opp_12_grip",
    "elite_opp_12_sc" }
},
new RacerProfile
{
    Tag = "ELITENAME_013", Name = "Antoine Gaskins", AssignedRaces = new string[] { "elite_opp_13_drag",
    "elite_opp_13_drift",
    "elite_opp_13_grip",
    "elite_opp_13_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_014", Name = "Tobias Sachenbacher", AssignedRaces = new string[] { "elite_opp_14_drag",
    "elite_opp_14_drift",
    "elite_opp_14_grip",
    "elite_opp_14_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_015", Name = "Kelvin Coates", AssignedRaces = new string[] { "elite_opp_15_drag",
    "elite_opp_15_drift",
    "elite_opp_15_grip",
    "elite_opp_15_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_016", Name = "Andreas Romanoff", AssignedRaces = new string[] {"elite_opp_16_drag",
    "elite_opp_16_drift",
    "elite_opp_16_grip",
    "elite_opp_16_sc" }
},
new RacerProfile
{
    Tag = "ELITENAME_017", Name = "Armand Walker", AssignedRaces = new string[] { "elite_opp_17_drag",
    "elite_opp_17_drift",
    "elite_opp_17_grip",
    "elite_opp_17_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_018", Name = "Ulrik Armstrong", AssignedRaces = new string[] { "elite_opp_18_drag",
    "elite_opp_18_drift",
    "elite_opp_18_grip",
    "elite_opp_18_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_019", Name = "Rudolph Reese", AssignedRaces = new string[] {"elite_opp_19_drag",
    "elite_opp_19_drift",
    "elite_opp_19_grip",
    "elite_opp_19_sc" }
},
new RacerProfile
{
    Tag = "ELITENAME_020", Name = "Tristan Christopher", AssignedRaces = new string[] { "elite_opp_20_drag",
    "elite_opp_20_drift",
    "elite_opp_20_grip",
    "elite_opp_20_sc"}
},
new RacerProfile
{
    Tag = "ELITENAME_021", Name = "Derek Anderson", AssignedRaces = new string[] { "elite_opp_21_drag" }
},
new RacerProfile
{
    Tag = "ELITENAME_022", Name = "Josh Mason", AssignedRaces = new string[] { "elite_opp_22_drag" }
},
new RacerProfile
{
    Tag = "ELITENAME_023", Name = "Corey Digger", AssignedRaces = new string[] { "elite_opp_26_drag" }
},
new RacerProfile
{
    Tag = "ELITENAME_024", Name = "Brad Adams", AssignedRaces = new string[] { "elite_opp_24_drag" }
},
new RacerProfile
{
    Tag = "ELITENAME_025", Name = "Cole Smith", AssignedRaces = new string[] { "elite_opp_25_drag" }
},
new RacerProfile
{
    Tag = "ELITENAME_026", Name = "Jimmy Sway", AssignedRaces = new string[] { "elite_opp_26_drag", "elite_opp_26_drag" }
},
new RacerProfile
{
    Tag = "ELITENAME_027", Name = "Tony Smalls", AssignedRaces = new string[] { "elite_opp_27_grip" }
},

// DDay Racers
new RacerProfile
{
    Tag = "DDAY_OPP_01", Name = "Eddie Cargo", AssignedRaces = new string[] { "dday_opp_1_grip" }
},
new RacerProfile
{
    Tag = "DDAY_OPP_02", Name = "Benny Gold", AssignedRaces = new string[] { "dday_opp_2_grip" }
},
new RacerProfile
{
    Tag = "DDAY_OPP_03", Name = "Samantha Cross", AssignedRaces = new string[] { "dday_opp_3_grip" }
},
new RacerProfile
{
    Tag = "DDAY_OPP_04", Name = "Bill Vein", AssignedRaces = new string[] { "dday_opp_4_grip" }
},
new RacerProfile
{
    Tag = "DDAY_OPP_05", Name = "Mark Mann", AssignedRaces = new string[] { "dday_opp_5_grip" }
},
new RacerProfile
{
    Tag = "DDAY_OPP_06", Name = "Roger Sole", AssignedRaces = new string[] { "dday_opp_6_grip" }
},
new RacerProfile
{
    Tag = "DDAY_OPP_07", Name = "Wilson Wong", AssignedRaces = new string[] { "dday_opp_7_grip" }
},

// Drag Entourage
new RacerProfile
{
    Tag = "DRAG_ENTOURAGE_1", Name = "Bradley Hunter", AssignedRaces = new string[] { "drag_entourage_1_drag" }
},
new RacerProfile
{
    Tag = "DRAG_ENTOURAGE_2", Name = "Frank Book", AssignedRaces = new string[] { "drag_entourage_2_drag" }
},
new RacerProfile
{
    Tag = "DRAG_ENTOURAGE_3", Name = "Craig Wright", AssignedRaces = new string[] { "drag_entourage_3_drag" }
},

// Drift Entourage
new RacerProfile
{
    Tag = "DRIFT_ENTOURAGE_1", Name = "Yoshi Suzuki", AssignedRaces = new string[] { "drift_entourage_1_drift" }
},
new RacerProfile
{
    Tag = "DRIFT_ENTOURAGE_2", Name = "Tony Manilla", AssignedRaces = new string[] { "drift_entourage_2_drift" }
},
new RacerProfile
{
    Tag = "DRIFT_ENTOURAGE_3", Name = "Vinnie Gaul", AssignedRaces = new string[] { "drift_entourage_3_drift" }
},

// Grip Entourage
new RacerProfile
{
    Tag = "GRIP_ENTOURAGE_1", Name = "Rudy Chen", AssignedRaces = new string[] { "grip_entourage_1_grip" }
},
new RacerProfile
{
    Tag = "GRIP_ENTOURAGE_2", Name = "Gavin May", AssignedRaces = new string[] { "grip_entourage_2_grip" }
},
new RacerProfile
{
    Tag = "GRIP_ENTOURAGE_3", Name = "Henrik Dehn", AssignedRaces = new string[] { "grip_entourage_3_grip" }
},

// Kings
new RacerProfile
{
    Tag = "Drag King", Name = "Karol Monroe", AssignedRaces = new string[] { "drag_king" }
},
new RacerProfile
{
    Tag = "Drift King", Name = "Aki Kimura", AssignedRaces = new string[] { "drift_king"}
},
new RacerProfile
{
    Tag = "Shadow King", Name = "Ryo Watanabe", AssignedRaces = new string[] { "showdown_king_final_drag",
    "showdown_king_final_drift",
    "showdown_king_final_grip",
    "showdown_king_final_sc",
    "showdown_king_playable"}
},
new RacerProfile
{
    Tag = "Speed King", Name = "Nate Denver", AssignedRaces = new string[] { "sc_king"}
},
new RacerProfile
{
    Tag = "Grip King", Name = "Ray Krieger", AssignedRaces = new string[] {"grip_king" }
},

// Showdown Entourage
new RacerProfile
{
    Tag = "SHOWDOWN_ENTOURAGE_1", Name = "Joe Tackett", AssignedRaces = new string[] {"showdown_entourage_1_drag",
    "showdown_entourage_1_grip",
    "showdown_entourage_1_sc" }
},
new RacerProfile
{
    Tag = "SHOWDOWN_ENTOURAGE_2", Name = "Takeshi Sato", AssignedRaces = new string[] { "showdown_entourage_2_drag",
    "showdown_entourage_2_drift",
    "showdown_entourage_2_grip",
    "showdown_entourage_2_sc"}
},
new RacerProfile
{
    Tag = "SHOWDOWN_ENTOURAGE_3", Name = "Ivan Tarkovsky", AssignedRaces = new string[] { "showdown_entourage_3_drag",
    "showdown_entourage_3_grip",
    "showdown_entourage_3_sc"}
},
new RacerProfile
{
    Tag = "SHOWDOWN_ENTOURAGE_4", Name = "Paul Trask", AssignedRaces = new string[] {"showdown_entourage_4_drag",
    "showdown_entourage_4_grip",
    "showdown_entourage_4_sc" }
},

// Speed Entourage
new RacerProfile
{
    Tag = "SC_ENTOURAGE_1", Name = "Paulo Cruz", AssignedRaces = new string[] { "sc_entourage_1_sc" }
},
new RacerProfile
{
    Tag = "SC_ENTOURAGE_2", Name = "JP Laurent", AssignedRaces = new string[] { "sc_entourage_2_sc" }
},
new RacerProfile
{
    Tag = "SC_ENTOURAGE_3", Name = "Carlos Galliano", AssignedRaces = new string[] { "sc_entourage_3_sc" }
},

/*{ "RACERNAME_002", "Paul Ko" },
{ "RACERNAME_003", "Don Berry" },
{ "RACERNAME_004", "Pete Carter" },
{ "RACERNAME_005", "Eddy Spencer" },
{ "RACERNAME_006", "Bill Newman" },
{ "RACERNAME_007", "Will Jackson" },
{ "RACERNAME_008", "Carl Sanner" },
{ "RACERNAME_009", "Dale Bennett" },
{ "RACERNAME_010", "Felix Tang" },
{ "RACERNAME_011", "Pedro Wilson" },
{ "RACERNAME_012", "Wade Jackson" },
{ "RACERNAME_013", "Angelo Rowley" },
{ "RACERNAME_014", "Adrian Reed" },
{ "RACERNAME_015", "Christopher Jones" },
{ "RACERNAME_016", "Blaine Cook" },
{ "RACERNAME_017", "Chad Byers" },
{ "RACERNAME_018", "Travis Bratton" },
{ "RACERNAME_019", "Ron Chen" },
{ "RACERNAME_020", "Masahide Omura" },
{ "RACERNAME_021", "Kazutoshi Kawakami" },
{ "RACERNAME_022", "Ryoma Shibasawa" },
{ "RACERNAME_023", "Shinji Takasu" },
{ "RACERNAME_024", "Ukyo Ihara" },
{ "RACERNAME_025", "Masato Kihara" },
{ "RACERNAME_026", "Sadatake Ueshima" },
{ "RACERNAME_027", "Atshushi Muraguchi" },
{ "RACERNAME_028", "Shinji Mori" },
{ "RACERNAME_029", "Kaneko Hiroyori" },
{ "RACERNAME_030", "Tomonori Uetake" },
{ "RACERNAME_031", "Kohji Yamagata" },
{ "RACERNAME_032", "Kazu Yoshida" },
{ "RACERNAME_033", "Makoto Yoshizawa" },
{ "RACERNAME_034", "Yoshiaki Kawakami" },
{ "RACERNAME_035", "Conrad Miller" },
{ "RACERNAME_036", "Fred Watkins" },
{ "RACERNAME_037", "Diego Wolfe" },
{ "RACERNAME_038", "Marcel Porter" },
{ "RACERNAME_039", "Jonathan Evans" },
{ "RACERNAME_040", "Takuya Kawayama" },
{ "RACERNAME_041", "Satoshi Hosokaya" },
{ "RACERNAME_042", "Mitsuharu Tanaka" },
{ "RACERNAME_043", "Naoki Yoshihara" },
{ "RACERNAME_044", "Hiroaki Terasawa" },
{ "RACERNAME_045", "Munehiko Kawaguchi" },
{ "RACERNAME_046", "Mitsuhide Nakamura" },
{ "RACERNAME_047", "Yoshio Sato" },
{ "RACERNAME_048", "Charlie Heyman" },
{ "RACERNAME_049", "Colby Canham" },
{ "RACERNAME_050", "Brandon Tennant ^" },
{ "RACERNAME_051", "Perry Prescott" },
{ "RACERNAME_052", "Oliver Armitage" },
{ "RACERNAME_053", "Don Braun" },
{ "RACERNAME_054", "Seb Crawford" },
{ "RACERNAME_055", "Tyron Bryan" },
{ "RACERNAME_056", "Stuart Mitchell" },
{ "RACERNAME_057", "Kyle Easter" },
{ "RACERNAME_058", "Scott East" },
{ "RACERNAME_059", "Rory Taggart" },
{ "RACERNAME_060", "Mike Lineman" },
{ "RACERNAME_061", "Matt Pritchard" },
{ "RACERNAME_062", "Karl Losey" },
{ "RACERNAME_063", "Ben Haverman" },
{ "RACERNAME_064", "Filip Douglas" },
{ "RACERNAME_065", "Marcel Buddenseik" },
{ "RACERNAME_066", "Chet Higgens" },
{ "RACERNAME_067", "Klaus Steele" },
{ "RACERNAME_068", "Gustavo Demetrius" },
{ "RACERNAME_069", "Dominik Wilkins" },
{ "RACERNAME_070", "Charlie Gaskins" },
{ "RACERNAME_071", "Bill Tireman" },
{ "RACERNAME_072", "Al Gregg" },
{ "RACERNAME_073", "Rob Chase" },
{ "RACERNAME_074", "Bruno Hardy" },

// Booster Racers
{ "BOOST_RACERNAME_001", "Carey Hill" },
{ "BOOST_RACERNAME_002", "Dustin Elton" },
{ "BOOST_RACERNAME_003", "Josh Fairview" },
{ "BOOST_RACERNAME_004", "David Con" },
{ "BOOST_RACERNAME_005", "Manny Solemn" },
{ "BOOST_RACERNAME_006", "Konrad Mull" },
{ "BOOST_RACERNAME_007", "Victor Hesh" },
{ "BOOST_RACERNAME_008", "Clayton Mason" },
{ "BOOST_RACERNAME_009", "Nikki Swan" },
{ "BOOST_RACERNAME_010", "Jake Winston" },
{ "BOOST_RACERNAME_012", "Edward Hamilton" },
{ "BOOST_RACERNAME_014", "Gary Right" },
{ "BOOST_RACERNAME_016", "Vincent Strongarm" },
{ "BOOST_RACERNAME_018", "John Laurier" },
{ "BOOST_RACERNAME_019", "Jimmy Plant" },
{ "BOOST_RACERNAME_020", "Ashley Veer" },
{ "BOOST_RACERNAME_021", "Carl Money" },
{ "BOOST_RACERNAME_022", "Eduardo Williams" },

// Elite Racers
{ "ELITENAME_001", "Mamoru Arakawa" },
{ "ELITENAME_002", "Seiko Makiguchi" },
{ "ELITENAME_003", "Tsuneo Hamamoto" },
{ "ELITENAME_004", "Takeshi Tatsumi" },
{ "ELITENAME_005", "Ryota Iwahara" },
{ "ELITENAME_006", "Shiheru Mitani" },
{ "ELITENAME_007", "Takejiro Okuda" },
{ "ELITENAME_008", "Hide Okui" },
{ "ELITENAME_009", "Masao Hasekura" },
{ "ELITENAME_010", "Minoru Higashiyama" },
{ "ELITENAME_011", "Hitoshi Morie" },
{ "ELITENAME_012", "Nobu Sawayama" },
{ "ELITENAME_013", "Antoine Gaskins" },
{ "ELITENAME_014", "Tobias Sachenbacher" },
{ "ELITENAME_015", "Kelvin Coates" },
{ "ELITENAME_016", "Andreas Romanoff" },
{ "ELITENAME_017", "Armand Walker" },
{ "ELITENAME_018", "Ulrik Armstrong" },
{ "ELITENAME_019", "Rudolph Reese" },
{ "ELITENAME_020", "Tristan Christopher" },
{ "ELITENAME_021", "Derek Anderson" },
{ "ELITENAME_022", "Josh Mason" },
{ "ELITENAME_023", "Corey Digger" },
{ "ELITENAME_024", "Brad Adams" },
{ "ELITENAME_025", "Cole Smith" },
{ "ELITENAME_026", "Jimmy Sway" },
{ "ELITENAME_027", "Tony Smalls" },

// DDay Racers
{ "DDAY_OPP_01", "Eddie Cargo" },
{ "DDAY_OPP_02", "Benny Gold" },
{ "DDAY_OPP_03", "Samantha Cross" },
{ "DDAY_OPP_04", "Bill Vein" },
{ "DDAY_OPP_05", "Mark Mann" },
{ "DDAY_OPP_06", "Roger Sole" },
{ "DDAY_OPP_07", "Wilson Wong" },

// Drag Entourage
{ "DRAG_ENTOURAGE_1", "Bradley Hunter" },
{ "DRAG_ENTOURAGE_2", "Frank Book" },
{ "DRAG_ENTOURAGE_3", "Craig Wright" },

// Drift Entourage
{ "DRIFT_ENTOURAGE_1", "Yoshi Suzuki" },
{ "DRIFT_ENTOURAGE_2", "Tony Manilla" },
{ "DRIFT_ENTOURAGE_3", "Vinnie Gaul" },

// Grip Entourage
{ "GRIP_ENTOURAGE_1", "Rudy Chen" },
{ "GRIP_ENTOURAGE_2", "Gavin May" },
{ "GRIP_ENTOURAGE_3", "Henrik Dehn" },

// Kings
{ "Drag King", "Karol Monroe" },
{ "Drift King", "Aki Kimura" },
{ "Shadow King", "Ryo Watanabe" },
{ "Speed King", "Nate Denver" },
{ "Grip King",  "Ray Krieger" },

// Showdown Entourage
{ "SHOWDOWN_ENTOURAGE_1", "Joe Tackett" },
{ "SHOWDOWN_ENTOURAGE_2", "Takeshi Sato" },
{ "SHOWDOWN_ENTOURAGE_3", "Ivan Tarkovsky" },
{ "SHOWDOWN_ENTOURAGE_4", "Paul Trask" },

// Speed Entourage
{ "SC_ENTOURAGE_1", "Paulo Cruz" },
{ "SC_ENTOURAGE_2", "JP Laurent" },
{ "SC_ENTOURAGE_3", "Carlos Galliano" }
    };
*/
};

        public static Dictionary<string, string> presetCarMap = new Dictionary<string, string>()
{
    // Temp / Challenge Presets
    { "ch_t3_inf_drag", "challenger71" },
    { "ch_t3_inf_drift", "nsx" },
    { "ch_t3_inf_grip", "caymans" },
    { "ch_t3_inf_grip2", "nsx" },
    { "p_ch_t1_nvd_drag", "cobaltss" },
    { "p_ch_t1_nvd_drag2", " civichb" },
    { "p_ch_t1_nvd_grip", "gti" },
    { "p_ch_t1_tx_drag", "gti" },
    { "p_ch_t1_tx_drift", "350z" },
    { "p_ch_t1_tx_grip", "gti" },
    { "p_ch_t1_tx_grip2", "350z" },
    { "p_ch_t1_willow_drag", "is350" },
    { "p_ch_t1_willow_drag2", "chevelle" },
    { "p_ch_t1_willow_drift", "chevelle" },
    { "p_ch_t1_willow_grip", "is350" },
    { "p_ch_t2_autop_drift", "gto" },
    { "p_ch_t2_autop_drift2", "g35" },
    { "p_ch_t2_autop_grip", "gto" },
    { "p_ch_t2_ce_autop_drift", "silvia" },
    { "p_ch_t2_ce_autop_grip", "silvia" },
    { "p_ch_t2_ce_autop_grip2", "solsticegxp" },
    { "p_ch_t2_eb_drift", "supra" },
    { "p_ch_t2_eb_grip", "bmwm3" },
    { "p_ch_t2_eb_sc", "bmwm3" },
    { "p_ch_t2_eb_sc2", "supra" },
    { "p_ch_t3_autob_drift", "viper" },
    { "p_ch_t3_autob_grip", "skyline" },
    { "p_ch_t3_autob_sc", "viper" },
    { "p_ch_t3_autob_sc2", "skyline" },
    { "p_ch_t3_nev_drag", "corvettez06" },
    { "p_ch_t3_nev_drift", "corvettez06" },
    { "p_ch_t3_nev_grip", "rs4" },
    { "p_ch_t3_nev_sc", "rs4" },
    { "p_ch_t3_nev_sc2", "corvettez06" },

    // Ad Sale / Promotional
    { "coke_gti", "gti" },
    { "energizer_viper", "viper" },

            // Bonus / Frontend Cars
    {"0x9b879916", "mazdaspeed3"},
    { "fe_drag_1_civichb", "civichb" },
    { "fe_drag_1_cobaltss", "cobaltss" },
    { "fe_drag_1_cuda", "cuda" },
    { "fe_drag_1_mustshlbyo", "mustangshlbyo" },
    { "fe_drag_2_charg69", "charger69" },
    { "fe_drag_2_eclipse", "eclipse" },
    { "fe_drag_2_evo09", "lancerevo9" },
    { "fe_drag_2_r32", "r32" },
    { "fe_drag_3_gti", "gti" },
    { "fe_drag_3_mustgt", "mustanggt" },
    { "fe_drag_3_skyline", "skyline" },
    { "fe_drag_3_wrx", "imprezawrxsti" },
    { "fe_drift_1_240sx", "240sx" },
    { "fe_drift_1_corolla", "corolla" },
    { "fe_drift_1_rx7", "rx7" },
    { "fe_drift_1_silvia", "silvia" },
    { "fe_drift_2_350z", "350z" },
    { "fe_drift_2_chevelle", "chevelle" },
    { "fe_drift_2_g35", "g35" },
    { "fe_drift_2_supra", "supra" },
    { "fe_drift_3_c6", "corvette" },
    { "fe_drift_3_challenger", "challenger71" },
    { "fe_drift_3_rx8", "rx8" },
    { "fe_drift_3_viper", "viper" },
    { "fe_grip_1_charger69", "charger69" },
    { "fe_grip_1_chevelle", "chevelle" },
    { "fe_grip_1_corolla", "corolla" },
    { "fe_grip_1_rx8", "rx8" },
    { "fe_grip_2_cosworth", "cosworth" },
    { "fe_grip_2_eclipse", "eclipse" },
    { "fe_grip_2_g35", "g35" },
    { "fe_grip_2_s3", "s3" },
    { "fe_grip_3_corvc6", "corvette" },
    { "fe_grip_3_gto", "gto" },
    { "fe_grip_3_murc640", "murcielago640" },
    { "fe_grip_3_supra", "supra" },
    { "fe_sc_1_chall71", "challenger71" },
    { "fe_sc_1_cosworth", "cosworth" },
    { "fe_sc_1_r32", "r32" },
    { "fe_sc_1_s3", "s3" },
    { "fe_sc_2_elise", "elise" },
    { "fe_sc_2_rx8", "rx8" },
    { "fe_sc_2_silvia", "silvia" },
    { "fe_sc_3_camaross", "camaro" },
    { "fe_sc_3_caymans", "caymans" },
    { "fe_sc_3_fordgt", "fordgt" },
    { "fe_sc_3_s4", "s4" },

    // Booster Opponents - Drag
    { "b_opp_1_drag", "dlcbp_challengern" },
    { "b_opp_10_drag", "ttn" },
    { "b_opp_12_drag", "dlcbp_r8prod" },
    { "b_opp_14_drag", "dlcbp_s2000" },
    { "b_opp_16_drag", "dlcbp_gallardos" },
    { "b_opp_18_drag", "dlcbp_sl65" },
    { "b_opp_19_drag", "dlcbp_db9" },
    { "b_opp_2_drag", "dlcbp_delta" },
    { "b_opp_20_drag", "dlcbp_997gt3" },
    { "b_opp_21_drag", "dlcbp_997gt3rs" },
    { "b_opp_22_drag", "dlcbp_carreragt" },
    { "b_opp_3_drag", "dlcbp_roadrunner" },
    { "b_opp_4_drag", "dlcbp_leoncupra" },
    { "b_opp_5_drag", "dlcbp_challengern" },
    { "b_opp_6_drag", "dlcbp_delta" },
    { "b_opp_7_drag", "dlcbp_roadrunner" },
    { "b_opp_8_drag", "dlcbp_leoncupra" },
    { "b_opp_9_drag", "mustang03" },

    // Booster Opponents - Drift
    { "b_opp_1_drift", "dlcbp_challengern" },
    { "b_opp_10_drift", " bmwmz4" },
    { "b_opp_12_drift", "dlcbp_challengern" },
    { "b_opp_14_drift", "dlcbp_s2000" },
    { "b_opp_16_drift", "dlcbp_s2000" },
    { "b_opp_18_drift", "dlcbp_sl65" },
    { "b_opp_19_drift", "dlcbp_db9" },
    { "b_opp_2_drift", "nsx" },
    { "b_opp_20_drift", "dlcbp_997gt3" },
    { "b_opp_21_drift", "dlcbp_997gt3rs" },
    { "b_opp_22_drift", "dlcbp_carreragt" },
    { "b_opp_3_drift", "dlcbp_roadrunner" },
    { "b_opp_4_drift", "solsticegxp" },
    { "b_opp_5_drift", "dlcbp_challengern" },
    { "b_opp_6_drift", "is350" },
    { "b_opp_7_drift", "dlcbp_roadrunner" },
    { "b_opp_8_drift", "997gt2" },
    { "b_opp_9_drift", "mustang03" },

    // Booster Opponents - Grip
    { "b_opp_1_grip", "dlcbp_challengern" },
    { "b_opp_10_grip", "ttn" },
    { "b_opp_12_grip", "dlcbp_r8prod" },
    { "b_opp_14_grip", "dlcbp_s2000" },
    { "b_opp_16_grip", "dlcbp_gallardos" },
    { "b_opp_18_grip", "dlcbp_sl65" },
    { "b_opp_19_grip", "dlcbp_db9" },
    { "b_opp_2_grip", "dlcbp_delta" },
    { "b_opp_20_grip", "dlcbp_997gt3" },
    { "b_opp_21_grip", "dlcbp_997gt3rs" },
    { "b_opp_22_grip", "dlcbp_carreragt" },
    { "b_opp_3_grip", "dlcbp_roadrunner" },
    { "b_opp_4_grip", "dlcbp_leoncupra" },
    { "b_opp_5_grip", "dlcbp_challengern" },
    { "b_opp_6_grip", "dlcbp_delta" },
    { "b_opp_7_grip", "dlcbp_roadrunner" },
    { "b_opp_8_grip", "dlcbp_leoncupra" },
    { "b_opp_9_grip", "mustang03" },

    // Booster Opponents - Speed Challenge
    { "b_opp_1_sc", "dlcbp_challengern" },
    { "b_opp_10_sc", "ttn" },
    { "b_opp_12_sc", "dlcbp_r8prod" },
    { "b_opp_14_sc", "dlcbp_s2000" },
    { "b_opp_16_sc", "dlcbp_gallardos" },
    { "b_opp_18_sc", "dlcbp_sl65" },
    { "b_opp_19_sc", "dlcbp_db9" },
    { "b_opp_2_sc", "dlcbp_delta" },
    { "b_opp_20_sc", "dlcbp_997gt3" },
    { "b_opp_21_sc", "dlcbp_997gt3rs" },
    { "b_opp_22_sc", "dlcbp_carreragt" },
    { "b_opp_3_sc", "dlcbp_roadrunner" },
    { "b_opp_4_sc", "dlcbp_leoncupra" },
    { "b_opp_5_sc", "dlcbp_challengern" },
    { "b_opp_6_sc", "dlcbp_delta" },
    { "b_opp_7_sc", "dlcbp_roadrunner" },
    { "b_opp_8_sc", "dlcbp_leoncupra" },
    { "b_opp_9_sc", "mustang03" },

    // Commercial / Promotional Cars
    { "commercial_ae86", "corolla" },
    { "commercial_camaro", "camaro" },
    { "commercial_cuda", "cuda" },
    { "commercial_e92", "bmwm3e92" },
    { "commercial_evo", "lancerevo9" },
    { "commercial_fordgt", "fordgt" },
    { "commercial_gt2", "997gt2" },
    { "commercial_mustang", "mustanggt" },
    { "commercial_mustang_old", "mustanggt" },
    { "commercial_proto", "gtrproto" },
    { "commercial_rx7", "rx7" },
    { "commercial_s15", "silvia" },
    { "commercial_s4", "s4" },
    { "commercial_wrx", "imprezawrxsti" },

    // Debug / Dev Presets
    { "jacques_mobile", "rx7" },
    { "jacques_mobile_drag", "0x195b4ae8" },
    { "jacques_mobile_grip", "350z" },
    { "jacques_mobile_speed", "350z" },

    // Entourage Drag
    { "drag_entourage_1_drag", "chevelle" },
    { "drag_entourage_2_drag", "challenger71" },
    { "drag_entourage_3_drag", "gto" },
    { "showdown_entourage_1_drag", "civichb" },
    { "showdown_entourage_2_drag", "silvia" },
    { "showdown_entourage_3_drag", "lancerevo9" },
    { "showdown_entourage_4_drag", "skyline" },

    // Entourage Drift
    { "drift_entourage_1_drift", "350z" },
    { "drift_entourage_2_drift", "camaro" },
    { "drift_entourage_3_drift", "corolla" },
    { "showdown_entourage_2_drift", "silvia" },

    // Entourage Grip
    { "grip_entourage_1_grip", "997tt" },
    { "grip_entourage_2_grip", "cosworth" },
    { "grip_entourage_3_grip", "s4" },
    { "showdown_entourage_1_grip", "civichb" },
    { "showdown_entourage_2_grip", "silvia" },
    { "showdown_entourage_3_grip", "lancerevo9" },
    { "showdown_entourage_4_grip", "skyline" },

    // Entourage Speed Challenge
    { "sc_entourage_1_sc", "corvettez06" },
    { "sc_entourage_2_sc", "zonda" },
    { "sc_entourage_3_sc", "supra" },
    { "showdown_entourage_1_sc", "civichb" },
    { "showdown_entourage_2_sc", "silvia" },
    { "showdown_entourage_3_sc", "lancerevo9" },
    { "showdown_entourage_4_sc", "skyline" },

    // Boss / King Cars
    { "drag_king", "mustanggt" },
    { "drift_king", "rx7" },
    { "grip_king", "bmwm3e92" },
    { "sc_king", "gto65" },
    { "showdown_king_final_drag", "showdown_king" },
    { "showdown_king_final_drift", "showdown_king" },
    { "showdown_king_final_grip", "lancerevox" },
    { "showdown_king_final_sc", "lancerevox" },
    { "showdown_king_playable", "lancerevox" },

    // Challenge Mode - Drag
    { "ch_t1_ptl_drag_civichb", "civichb" },
    { "ch_t1_ptl_drag_mustgt", "cobaltss" },
    { "ch_t1_tx_drag_gti", "gti" },
    { "ch_t1_willow_drag_chevelle", "chevelle" },
    { "ch_t3_infineon_drag_cayman", "challenger71" },
    { "ch_t3_nevada_drag_z06", "corvettez06" },

    // Challenge Mode - Drift
    { "ch_t1_tx_drift_350z", "350z" },
    { "ch_t1_willow_drift_chevelle", "chevelle" },
    { "ch_t1_willow_drift_is350", "is350" },
    { "ch_t2_autop_drift_s15", "silvia" },
    { "ch_t2_autop_drift_solstice", "solsticegxp" },
    { "ch_t2_ebisu_drift_supra", "supra" },
    { "ch_t2_mond_drift_g35", "g35" },
    { "ch_t2_mond_drift_gto", "gto" },
    { "ch_t3_autob_drift_viper", "viper" },
    { "ch_t3_infineon_drift_nsx", "nsx" },
    { "ch_t3_nevada_drift_z06", "corvettez06" },

    // Challenge Mode - Grip
    { "ch_t1_ptl_grip_civichb", "gti" },
    { "ch_t1_tx_grip_350z", "350z" },
    { "ch_t1_tx_grip_gti", "gti" },
    { "ch_t1_willow_grip_is350", "is350" },
    { "ch_t2_autop_grip_s15", "silvia" },
    { "ch_t2_ebisu_grip_bmwm3", "bmwm3" },
    { "ch_t2_mond_grip_gto", "gto" },
    { "ch_t3_autob_grip_skyline", "skyline" },
    { "ch_t3_infineon_grip_cayman", "caymans" },
    { "ch_t3_infineon_grip_nsx", "nsx" },
    { "ch_t3_nevada_grip_rs4", "rs4" },

    // Challenge Mode - Speed Challenge
    { "ch_t2_ebisu_sc_bmwm3", "bmwm3" },
    { "ch_t2_ebisu_sc_supra", "supra" },
    { "ch_t3_autob_sc_skyline", "skyline" },
    { "ch_t3_autob_sc_viper", "viper" },
    { "ch_t3_nevada_sc_rs4", "rs4" },
    { "ch_t3_nevada_sc_z06", "corvettez06" },

    // D-Day Event
    { "dday_opp_1_grip", "civichb" },
    { "dday_opp_2_grip", "corolla" },
    { "dday_opp_3_grip", "240sx" },
    { "dday_opp_4_grip", "civichb" },
    { "dday_opp_5_grip", "240sx" },
    { "dday_opp_6_grip", "corolla" },
    { "dday_opp_7_grip", "civichb" },

    // Elite Opponents - Drag
    { "elite_opp_1_drag", "rx7" },
    { "elite_opp_11_drag", "350z" },
    { "elite_opp_12_drag", "240sx" },
    { "elite_opp_13_drag", "bmwm3e92" },
    { "elite_opp_14_drag", "gtrproto" },
    { "elite_opp_15_drag", "ctsv" },
    { "elite_opp_16_drag", "corvettez06" },
    { "elite_opp_17_drag", "mustangshlbyn" },
    { "elite_opp_18_drag", "mustanggt" },
    { "elite_opp_19_drag", "viper" },
    { "elite_opp_2_drag", "silvia" },
    { "elite_opp_20_drag", "fordgt" },
    { "elite_opp_21_drag", "charger69" },
    { "elite_opp_22_drag", "mustangshlbyn" },
    { "elite_opp_23_drag", "challenger71" },
    { "elite_opp_24_drag", "cuda" },
    { "elite_opp_25_drag", "camaro" },
    { "elite_opp_26_drag", "gto" },
    { "elite_opp_3_drag", "skyline" },
    { "elite_opp_4_drag", "rx8" },
    { "elite_opp_5_drag", "supra" },

    // Elite Opponents - Drift
    { "elite_opp_1_drift", "240sx" },
    { "elite_opp_11_drift", "rx7" },
    { "elite_opp_12_drift", "supra" },
    { "elite_opp_13_drift", "viper" },
    { "elite_opp_14_drift", "mustangshlbyn" },
    { "elite_opp_15_drift", "gto" },
    { "elite_opp_16_drift", "mustangshlbyn" },
    { "elite_opp_17_drift", "viper" },
    { "elite_opp_18_drift", "cuda" },
    { "elite_opp_19_drift", "corvettez06" },
    { "elite_opp_2_drift", "rx8" },
    { "elite_opp_20_drift", "viper" },
    { "elite_opp_3_drift", "corolla" },
    { "elite_opp_4_drift", "350z" },
    { "elite_opp_5_drift", "silvia" },

    // Elite Opponents - Grip
    { "elite_opp_1_grip", "gtrproto" },
    { "elite_opp_11_grip", "bmwm3" },
    { "elite_opp_12_grip", "s3" },
    { "elite_opp_13_grip", "caymans" },
    { "elite_opp_14_grip", "997tt" },
    { "elite_opp_15_grip", "viper" },
    { "elite_opp_16_grip", "murcielago640" },
    { "elite_opp_17_grip", "fordgt" },
    { "elite_opp_18_grip", "lancerevox" },
    { "elite_opp_19_grip", "bmwm3e92" },
    { "elite_opp_2_grip", "focusst" },
    { "elite_opp_20_grip", "corvettez06" },
    { "elite_opp_27_grip", "r32" },
    { "elite_opp_3_grip", "gtrproto" },
    { "elite_opp_4_grip", "skyline" },
    { "elite_opp_5_grip", "lancerevo9" },

    // Elite Opponents - Speed Challenge
    { "elite_opp_1_sc", "lancerevox" },
    { "elite_opp_11_sc", "gtrproto" },
    { "elite_opp_12_sc", "skyline" },
    { "elite_opp_13_sc", "murcielago640" },
    { "elite_opp_14_sc", "zonda" },
    { "elite_opp_15_sc", "mustangshlbyn" },
    { "elite_opp_16_sc", "997tt" },
    { "elite_opp_17_sc", "corvettez06" },
    { "elite_opp_18_sc", "viper" },
    { "elite_opp_19_sc", "fordgt" },
    { "elite_opp_2_sc", "gtrproto" },
    { "elite_opp_20_sc", "mustanggt" },
    { "elite_opp_3_sc", "supra" },
    { "elite_opp_4_sc", "350z" },
    { "elite_opp_5_sc", "rx7" },

    // HD / Race Day Opponents - Drag
    { "hd_opp_1_drag", "rsx" },
    { "hd_opp_10_drag", "rs4" },
    { "hd_opp_11_drag", "camaron" },
    { "hd_opp_12_drag", "mustang03" },
    { "hd_opp_13_drag", "is350" },
    { "hd_opp_14_drag", "integratyper" },
    { "hd_opp_15_drag", "viper" },
    { "hd_opp_2_drag", "cobaltss" },
    { "hd_opp_3_drag", "rsx" },
    { "hd_opp_4_drag", "s3" },
    { "hd_opp_5_drag", "s3" },
    { "hd_opp_6_drag", "cosworth" },
    { "hd_opp_7_drag", "integrals" },
    { "hd_opp_8_drag", "civicsi" },
    { "hd_opp_9_drag", "corvette67" },

    // HD / Race Day Opponents - Drift
    { "hd_opp_1_drift", "charger69" },
    { "hd_opp_10_drift", "is350" },
    { "hd_opp_11_drift", "bmwm3e92" },
    { "hd_opp_12_drift", "camaron" },
    { "hd_opp_13_drift", "corvette" },
    { "hd_opp_14_drift", "nsx" },
    { "hd_opp_15_drift", "fordgt" },
    { "hd_opp_2_drift", "mustanggt" },
    { "hd_opp_3_drift", "240sx" },
    { "hd_opp_4_drift", "bmwm3" },
    { "hd_opp_5_drift", "camaro" },
    { "hd_opp_6_drift", "chevelle" },
    { "hd_opp_7_drift", "corolla" },
    { "hd_opp_8_drift", "solsticegxp" },
    { "hd_opp_9_drift", "solsticegxp" },

    // HD / Race Day Opponents - Grip
    { "hd_opp_1_grip", "corvette67" },
    { "hd_opp_10_grip", "integratyper" },
    { "hd_opp_11_grip", "rs4" },
    { "hd_opp_12_grip", "bmwmz4" },
    { "hd_opp_13_grip", "ctsv" },
    { "hd_opp_14_grip", "ttn" },
    { "hd_opp_15_grip", "997gt2" },
    { "hd_opp_2_grip", "mustangshlbyo" },
    { "hd_opp_3_grip", "rsx" },
    { "hd_opp_4_grip", "rsx" },
    { "hd_opp_5_grip", "corvette67" },
    { "hd_opp_6_grip", "civicsi" },
    { "hd_opp_7_grip", "s3" },
    { "hd_opp_8_grip", "integrals" },
    { "hd_opp_9_grip", "cuda" },

    // HD / Race Day Opponents - Speed Challenge
    { "hd_opp_1_sc", "gto65" },
    { "hd_opp_10_sc", "bmwm3e92" },
    { "hd_opp_11_sc", "ttn" },
    { "hd_opp_12_sc", "bmwmz4" },
    { "hd_opp_13_sc", "solsticegxp" },
    { "hd_opp_14_sc", "bmwmz4" },
    { "hd_opp_15_sc", "r32" },
    { "hd_opp_2_sc", "corvette67" },
    { "hd_opp_3_sc", "corvette67" },
    { "hd_opp_4_sc", "s3" },
    { "hd_opp_5_sc", "charger69" },
    { "hd_opp_6_sc", "integrals" },
    { "hd_opp_7_sc", "cobaltss" },
    { "hd_opp_8_sc", "mustangshlbyo" },
    { "hd_opp_9_sc", "civicsi" },

    // Generic Opponents - Drag
    { "opp_0_drag", "s3" },
    { "opp_1_drag", "gti" },
    { "opp_10_drag", "gti" },
    { "opp_11_drag", "gti" },
    { "opp_12_drag", "240sx" },
    { "opp_13_drag", "s3" },
    { "opp_14_drag", "s3" },
    { "opp_2_drag", "s3" },
    { "opp_20_drag", "350z" },
    { "opp_21_drag", "mazdaspeed3" },
    { "opp_22_drag", "eclipse" },
    { "opp_23_drag", "supra" },
    { "opp_24_drag", "eclipse" },
    { "opp_25_drag", "eclipse" },
    { "opp_26_drag", "silvia" },
    { "opp_27_drag", "civichb" },
    { "opp_28_drag", "civichb" },
    { "opp_29_drag", "mazdaspeed3" },
    { "opp_3_drag", "civichb" },
    { "opp_30_drag", "g35" },
    { "opp_31_drag", "supra" },
    { "opp_32_drag", "350z" },
    { "opp_33_drag", "lancerevo9" },
    { "opp_34_drag", "supra" },
    { "opp_4_drag", "gto65" },
    { "opp_41_drag", "g35" },
    { "opp_42_drag", "civichb" },
    { "opp_43_drag", "rx7" },
    { "opp_44_drag", "lancerevo9" },
    { "opp_45_drag", "supra" },
    { "opp_46_drag", "focusst" },
    { "opp_47_drag", "eclipse" },
    { "opp_48_drag", "cuda" },
    { "opp_49_drag", "gto" },
    { "opp_5_drag", "camaro" },
    { "opp_50_drag", "bmwm3" },
    { "opp_51_drag", "cobaltss" },
    { "opp_52_drag", "chevelle" },
    { "opp_53_drag", "camaro" },
    { "opp_54_drag", "corvette" },
    { "opp_6_drag", "civichb" },
    { "opp_7_drag", "240sx" },
    { "opp_8_drag", "240sx" },
    { "opp_9_drag", "civichb" },

    // Generic Opponents - Drift
    { "opp_0_drift", "challenger71" },
    { "opp_1_drift", "camaro" },
    { "opp_10_drift", "gto65" },
    { "opp_11_drift", "silvia" },
    { "opp_12_drift", "silvia" },
    { "opp_13_drift", "silvia" },
    { "opp_14_drift", "240sx" },
    { "opp_2_drift", "240sx" },
    { "opp_20_drift", "silvia" },
    { "opp_21_drift", "rx8" },
    { "opp_22_drift", "silvia" },
    { "opp_23_drift", "350z" },
    { "opp_24_drift", "supra" },
    { "opp_25_drift", "350z" },
    { "opp_26_drift", "corolla" },
    { "opp_27_drift", "240sx" },
    { "opp_28_drift", "g35" },
    { "opp_29_drift", "rx8" },
    { "opp_3_drift", "corolla" },
    { "opp_30_drift", "350z" },
    { "opp_31_drift", "g35" },
    { "opp_32_drift", "supra" },
    { "opp_33_drift", "silvia" },
    { "opp_34_drift", "corolla" },
    { "opp_4_drift", "camaro" },
    { "opp_41_drift", "rx7" },
    { "opp_42_drift", "240sx" },
    { "opp_43_drift", "silvia" },
    { "opp_44_drift", "rx7" },
    { "opp_45_drift", "350z" },
    { "opp_46_drift", "supra" },
    { "opp_47_drift", "corolla" },
    { "opp_48_drift", "bmwm3" },
    { "opp_49_drift", "gto" },
    { "opp_5_drift", "corolla" },
    { "opp_50_drift", "caymans" },
    { "opp_51_drift", "ctsv" },
    { "opp_52_drift", "mustanggt" },
    { "opp_53_drift", "corvette" },
    { "opp_54_drift", "mustanggt" },
    { "opp_6_drift", "240sx" },
    { "opp_7_drift", "240sx" },
    { "opp_8_drift", "corolla" },
    { "opp_9_drift", "camaro" },

    // Generic Opponents - Grip
    { "opp_0_grip", "mustangshlbyo" },
    { "opp_1_grip", "challenger71" },
    { "opp_10_grip", "cobaltss" },
    { "opp_11_grip", "cobaltss" },
    { "opp_12_grip", "chevelle" },
    { "opp_13_grip", "corolla" },
    { "opp_14_grip", "gti" },
    { "opp_2_grip", "charger69" },
    { "opp_20_grip", "350z" },
    { "opp_21_grip", "rx8" },
    { "opp_22_grip", "lancerevo9" },
    { "opp_23_grip", "g35" },
    { "opp_24_grip", "mazdaspeed3" },
    { "opp_25_grip", "lancerevo9" },
    { "opp_26_grip", "rx8" },
    { "opp_27_grip", "mazdaspeed3" },
    { "opp_28_grip", "eclipse" },
    { "opp_29_grip", "silvia" },
    { "opp_3_grip", "chevelle" },
    { "opp_30_grip", "supra" },
    { "opp_31_grip", "lancerevo9" },
    { "opp_32_grip", "supra" },
    { "opp_33_grip", "lancerevo9" },
    { "opp_34_grip", "350z" },
    { "opp_4_grip", "s3" },
    { "opp_41_grip", "imprezawrxsti" },
    { "opp_42_grip", "lancerevo9" },
    { "opp_43_grip", "rx7" },
    { "opp_44_grip", "g35" },
    { "opp_45_grip", "rx8" },
    { "opp_46_grip", "lancerevo9" },
    { "opp_47_grip", "imprezawrxsti" },
    { "opp_48_grip", "bmwm3" },
    { "opp_49_grip", "focusst" },
    { "opp_5_grip", "corolla" },
    { "opp_50_grip", "elise" },
    { "opp_51_grip", "bmwm3e92" },
    { "opp_52_grip", "mustanggt" },
    { "opp_53_grip", "corvette" },
    { "opp_54_grip", "caymans" },
    { "opp_6_grip", "civichb" },
    { "opp_7_grip", "240sx" },
    { "opp_8_grip", "corolla" },
    { "opp_9_grip", "charger69" },

    // Generic Opponents - Speed Challenge
    { "opp_0_sc", "gto65" },
    { "opp_1_sc", "mustangshlbyo" },
    { "opp_10_sc", "cobaltss" },
    { "opp_11_sc", "cobaltss" },
    { "opp_12_sc", "rx8" },
    { "opp_13_sc", "s4" },
    { "opp_14_sc", "r32" },
    { "opp_2_sc", "r32" },
    { "opp_20_sc", "g35" },
    { "opp_21_sc", "mazdaspeed3" },
    { "opp_22_sc", "lancerevo9" },
    { "opp_23_sc", "supra" },
    { "opp_24_sc", "silvia" },
    { "opp_25_sc", "g35" },
    { "opp_26_sc", "240sx" },
    { "opp_27_sc", "silvia" },
    { "opp_28_sc", "350z" },
    { "opp_29_sc", "civichb" },
    { "opp_3_sc", "cosworth" },
    { "opp_30_sc", "mazdaspeed3" },
    { "opp_31_sc", "350z" },
    { "opp_32_sc", "lancerevo9" },
    { "opp_33_sc", "eclipse" },
    { "opp_34_sc", "rx8" },
    { "opp_4_sc", "charger69" },
    { "opp_41_sc", "supra" },
    { "opp_42_sc", "rx7" },
    { "opp_43_sc", "g35" },
    { "opp_44_sc", "lancerevo9" },
    { "opp_45_sc", "imprezawrxsti" },
    { "opp_46_sc", "imprezawrxsti" },
    { "opp_47_sc", "lancerevo9" },
    { "opp_48_sc", "elise" },
    { "opp_49_sc", "corvette" },
    { "opp_5_sc", "camaro" },
    { "opp_50_sc", "gti" },
    { "opp_51_sc", "caymans" },
    { "opp_52_sc", "ctsv" },
    { "opp_53_sc", "gto65" },
    { "opp_54_sc", "bmwm3e92" },
    { "opp_6_sc", "civichb" },
    { "opp_7_sc", "240sx" },
    { "opp_8_sc", "240sx" },
    { "opp_9_sc", "charger69" },

    // Player Specific Presets
    { "player_ch_t1_ptl_grip_civichb", "gti" },
    { "player_ch_t1_ptl_grip_mustgt", "mustanggt" },
    { "player_d_day", "240sx" },

    // Screenshot Vehicles
    { "screenshot_240sx_grip_1", "240sx" },
    { "screenshot_911t_grip_1", "997tt_highend" },
    { "screenshot_ae86_grip_1", "corolla_highendscgrip" },
    { "screenshot_corvette_grip_1", "0xdeaab3f1" },
    { "screenshot_cuda_grip_1", "cuda_track" },
    { "screenshot_elise_grip_1", "elise_track" },
    { "screenshot_g35_grip_1", "g35_highendscgrip" },
    { "screenshot_gt500_grip_1", " mustangshlbyn_highendscgrip" },
    { "screenshot_is350_grip_1", "is350_highendscgrip" },
    { "screenshot_kobel_s15_grip_1", "silvia_highendscgrip" },
    { "screenshot_mustang_grip_1", " mustanggt_highendscgrip" },
    { "screenshot_rsx_grip_1", " rsx_track_highend" },
    { "screenshot_rx7_grip_1", "rx7_highend" },
    { "screenshot_rx8_grip_1", "rx8_highendscgrip" },
    { "screenshot_s15_grip_1", "silvia_highendscgrip" },
    { "screenshot_skyline_grip_1", "skyline_highendscgrip" },
    { "screenshot_supra_grip_1", "supra_highendscgrip" },

    // Web Tool Cars
    { "webtool_focus_1", "focusst" },
    { "webtool_focus_2", "focusst" },
    { "webtool_focus_3", "focusst" },
    { "webtool_rsx_1", "rsx" },
    { "webtool_rsx_2", "rsx" },
    { "webtool_rsx_3", "rsx" },
    { "webtool_sti_1", "imprezawrxsti" },
    { "webtool_sti_2", "imprezawrxsti" },
    { "webtool_sti_3", "imprezawrxsti" },
    { "webtool_ttn_1", "ttn" },
    { "webtool_ttn_2", "ttn" },
    { "webtool_ttn_3", "ttn" }
};

        /*
        string[] presets = new string[]
{
    //temp_for_challenge
    "ch_t3_inf_drag",
    "ch_t3_inf_drift",
    "ch_t3_inf_grip",
    "ch_t3_inf_grip2",
    "p_ch_t1_nvd_drag",
    "p_ch_t1_nvd_drag2",
    "p_ch_t1_nvd_grip",
    "p_ch_t1_tx_drag",
    "p_ch_t1_tx_drift",
    "p_ch_t1_tx_grip",
    "p_ch_t1_tx_grip2",
    "p_ch_t1_willow_drag",
    "p_ch_t1_willow_drag2",
    "p_ch_t1_willow_drift",
    "p_ch_t1_willow_grip",
    "p_ch_t2_autop_drift",
    "p_ch_t2_autop_drift2",
    "p_ch_t2_autop_grip",
    "p_ch_t2_ce_autop_drift",
    "p_ch_t2_ce_autop_grip",
    "p_ch_t2_ce_autop_grip2",
    "p_ch_t2_eb_drift",
    "p_ch_t2_eb_grip",
    "p_ch_t2_eb_sc",
    "p_ch_t2_eb_sc2",
    "p_ch_t3_autob_drift",
    "p_ch_t3_autob_grip",
    "p_ch_t3_autob_sc",
    "p_ch_t3_autob_sc2",
    "p_ch_t3_nev_drag",
    "p_ch_t3_nev_drift",
    "p_ch_t3_nev_grip",
    "p_ch_t3_nev_sc",
    "p_ch_t3_nev_sc2",
    //ad sale
    "coke_gti",
    "energizer_viper",
    //bonus cars
    //0x2ea1c400 is a preset ride with no name
    "fe_drag_1_civichb",
    "fe_drag_1_cobaltss",
    "fe_drag_1_cuda",
    "fe_drag_1_mustshlbyo",
    "fe_drag_2_charg69",
    "fe_drag_2_eclipse",
    "fe_drag_2_evo09",
    "fe_drag_2_r32",
    "fe_drag_3_gti",
    "fe_drag_3_mustgt",
    "fe_drag_3_skyline",
    "fe_drag_3_wrx",
    "fe_drift_1_240sx",
    "fe_drift_1_corolla",
    "fe_drift_1_rx7",
    "fe_drift_1_silvia",
    "fe_drift_2_350z",
    "fe_drift_2_chevelle",
    "fe_drift_2_g35",
    "fe_drift_2_supra",
    "fe_drift_3_c6",
    "fe_drift_3_challenger",
    "fe_drift_3_rx8",
    "fe_drift_3_viper",
    "fe_grip_1_charger69",
    "fe_grip_1_chevelle",
    "fe_grip_1_corolla",
    "fe_grip_1_rx8",
    "fe_grip_2_cosworth",
    "fe_grip_2_eclipse",
    "fe_grip_2_g35",
    "fe_grip_2_s3",
    "fe_grip_3_corvc6",
    "fe_grip_3_gto",
    "fe_grip_3_murc640",
    "fe_grip_3_supra",
    "fe_sc_1_chall71",
    "fe_sc_1_cosworth",
    "fe_sc_1_r32",
    "fe_sc_1_s3",
    "fe_sc_2_elise",
    "fe_sc_2_rx8",
    "fe_sc_2_silvia",
    "fe_sc_3_camaross",
    "fe_sc_3_caymans",
    "fe_sc_3_fordgt",
    "fe_sc_3_s4",
    //booster opponents
    // b_opp_drag
    "b_opp_1_drag",
    "b_opp_10_drag",
    "b_opp_12_drag",
    "b_opp_14_drag",
    "b_opp_16_drag",
    "b_opp_18_drag",
    "b_opp_19_drag",
    "b_opp_2_drag",
    "b_opp_20_drag",
    "b_opp_21_drag",
    "b_opp_22_drag",
    "b_opp_3_drag",
    "b_opp_4_drag",
    "b_opp_5_drag",
    "b_opp_6_drag",
    "b_opp_7_drag",
    "b_opp_8_drag",
    "b_opp_9_drag",

    // b_opp_drift
    "b_opp_1_drift",
    "b_opp_10_drift",
    "b_opp_12_drift",
    "b_opp_14_drift",
    "b_opp_16_drift",
    "b_opp_18_drift",
    "b_opp_19_drift",
    "b_opp_2_drift",
    "b_opp_20_drift",
    "b_opp_21_drift",
    "b_opp_22_drift",
    "b_opp_3_drift",
    "b_opp_4_drift",
    "b_opp_5_drift",
    "b_opp_6_drift",
    "b_opp_7_drift",
    "b_opp_8_drift",
    "b_opp_9_drift",

    // b_opp_grip
    "b_opp_1_grip",
    "b_opp_10_grip",
    "b_opp_12_grip",
    "b_opp_14_grip",
    "b_opp_16_grip",
    "b_opp_18_grip",
    "b_opp_19_grip",
    "b_opp_2_grip",
    "b_opp_20_grip",
    "b_opp_21_grip",
    "b_opp_22_grip",
    "b_opp_3_grip",
    "b_opp_4_grip",
    "b_opp_5_grip",
    "b_opp_6_grip",
    "b_opp_7_grip",
    "b_opp_8_grip",
    "b_opp_9_grip",

    // b_opp_sc
    "b_opp_1_sc",
    "b_opp_10_sc",
    "b_opp_12_sc",
    "b_opp_14_sc",
    "b_opp_16_sc",
    "b_opp_18_sc",
    "b_opp_19_sc",
    "b_opp_2_sc",
    "b_opp_20_sc",
    "b_opp_21_sc",
    "b_opp_22_sc",
    "b_opp_3_sc",
    "b_opp_4_sc",
    "b_opp_5_sc",
    "b_opp_6_sc",
    "b_opp_7_sc",
    "b_opp_8_sc",
    "b_opp_9_sc",
    //commersial
    "commercial_ae86",
    "commercial_camaro",
    "commercial_cuda",
    "commercial_e92",
    "commercial_evo",
    "commercial_fordgt",
    "commercial_gt2",
    "commercial_mustang",
    "commercial_mustang_old",
    "commercial_proto",
    "commercial_rx7",
    "commercial_s15",
    "commercial_s4",
    "commercial_wrx",
    // debug_presets
    "jacques_mobile",
    "jacques_mobile_drag",
    "jacques_mobile_grip",
    "jacques_mobile_speed",

    // entourage_drag
    "drag_entourage_1_drag",
    "drag_entourage_2_drag",
    "drag_entourage_3_drag",
    "showdown_entourage_1_drag",
    "showdown_entourage_2_drag",
    "showdown_entourage_3_drag",
    "showdown_entourage_4_drag",

    // entourage_drift
    "drift_entourage_1_drift",
    "drift_entourage_2_drift",
    "drift_entourage_3_drift",
    "showdown_entourage_2_drift",

    // entourage_grip
    "grip_entourage_1_grip",
    "grip_entourage_2_grip",
    "grip_entourage_3_grip",
    "showdown_entourage_1_grip",
    "showdown_entourage_2_grip",
    "showdown_entourage_3_grip",
    "showdown_entourage_4_grip",

    // entourage_sc
    "sc_entourage_1_sc",
    "sc_entourage_2_sc",
    "sc_entourage_3_sc",
    "showdown_entourage_1_sc",
    "showdown_entourage_2_sc",
    "showdown_entourage_3_sc",
    "showdown_entourage_4_sc",

    // king
    "drag_king",
    "drift_king",
    "grip_king",
    "sc_king",
    "showdown_king_final_drag",
    "showdown_king_final_drift",
    "showdown_king_final_grip",
    "showdown_king_final_sc",
    "showdown_king_playable",


    // challenge_drag
    "ch_t1_ptl_drag_civichb",
    "ch_t1_ptl_drag_mustgt",
    "ch_t1_tx_drag_gti",
    "ch_t1_willow_drag_chevelle",
    "ch_t3_infineon_drag_cayman",
    "ch_t3_nevada_drag_z06",

    // challenge_drift
    "ch_t1_tx_drift_350z",
    "ch_t1_willow_drift_chevelle",
    "ch_t1_willow_drift_is350",
    "ch_t2_autop_drift_s15",
    "ch_t2_autop_drift_solstice",
    "ch_t2_ebisu_drift_supra",
    "ch_t2_mond_drift_g35",
    "ch_t2_mond_drift_gto",
    "ch_t3_autob_drift_viper",
    "ch_t3_infineon_drift_nsx",
    "ch_t3_nevada_drift_z06",

    // challenge_grip
    "ch_t1_ptl_grip_civichb",
    "ch_t1_tx_grip_350z",
    "ch_t1_tx_grip_gti",
    "ch_t1_willow_grip_is350",
    "ch_t2_autop_grip_s15",
    "ch_t2_ebisu_grip_bmwm3",
    "ch_t2_mond_grip_gto",
    "ch_t3_autob_grip_skyline",
    "ch_t3_infineon_grip_cayman",
    "ch_t3_infineon_grip_nsx",
    "ch_t3_nevada_grip_rs4",

    // challenge_sc
    "ch_t2_ebisu_sc_bmwm3",
    "ch_t2_ebisu_sc_supra",
    "ch_t3_autob_sc_skyline",
    "ch_t3_autob_sc_viper",
    "ch_t3_nevada_sc_rs4",
    "ch_t3_nevada_sc_z06",

    // dday_grip
    "dday_opp_1_grip",
    "dday_opp_2_grip",
    "dday_opp_3_grip",
    "dday_opp_4_grip",
    "dday_opp_5_grip",
    "dday_opp_6_grip",
    "dday_opp_7_grip",

    // elite_drag
    "elite_opp_1_drag",
    "elite_opp_11_drag",
    "elite_opp_12_drag",
    "elite_opp_13_drag",
    "elite_opp_14_drag",
    "elite_opp_15_drag",
    "elite_opp_16_drag",
    "elite_opp_17_drag",
    "elite_opp_18_drag",
    "elite_opp_19_drag",
    "elite_opp_2_drag",
    "elite_opp_20_drag",
    "elite_opp_21_drag",
    "elite_opp_22_drag",
    "elite_opp_23_drag",
    "elite_opp_24_drag",
    "elite_opp_25_drag",
    "elite_opp_26_drag",
    "elite_opp_3_drag",
    "elite_opp_4_drag",
    "elite_opp_5_drag",

    // elite_drift
    "elite_opp_1_drift",
    "elite_opp_11_drift",
    "elite_opp_12_drift",
    "elite_opp_13_drift",
    "elite_opp_14_drift",
    "elite_opp_15_drift",
    "elite_opp_16_drift",
    "elite_opp_17_drift",
    "elite_opp_18_drift",
    "elite_opp_19_drift",
    "elite_opp_2_drift",
    "elite_opp_20_drift",
    "elite_opp_3_drift",
    "elite_opp_4_drift",
    "elite_opp_5_drift",

    // elite_grip
    "elite_opp_1_grip",
    "elite_opp_11_grip",
    "elite_opp_12_grip",
    "elite_opp_13_grip",
    "elite_opp_14_grip",
    "elite_opp_15_grip",
    "elite_opp_16_grip",
    "elite_opp_17_grip",
    "elite_opp_18_grip",
    "elite_opp_19_grip",
    "elite_opp_2_grip",
    "elite_opp_20_grip",
    "elite_opp_27_grip",
    "elite_opp_3_grip",
    "elite_opp_4_grip",
    "elite_opp_5_grip",
    // elite_sc
    "elite_opp_14_sc",
    "elite_opp_15_sc",
    "elite_opp_16_sc",
    "elite_opp_17_sc",
    "elite_opp_18_sc",
    "elite_opp_19_sc",
    "elite_opp_2_sc",
    "elite_opp_20_sc",
    "elite_opp_3_sc",
    "elite_opp_4_sc",
    "elite_opp_5_sc",

    // hd_drag
    "hd_opp_1_drag",
    "hd_opp_10_drag",
    "hd_opp_11_drag",
    "hd_opp_12_drag",
    "hd_opp_13_drag",
    "hd_opp_14_drag",
    "hd_opp_15_drag",
    "hd_opp_2_drag",
    "hd_opp_3_drag",
    "hd_opp_4_drag",
    "hd_opp_5_drag",
    "hd_opp_6_drag",
    "hd_opp_7_drag",
    "hd_opp_8_drag",
    "hd_opp_9_drag",

    // hd_drift
    "hd_opp_1_drift",
    "hd_opp_10_drift",
    "hd_opp_11_drift",
    "hd_opp_12_drift",
    "hd_opp_13_drift",
    "hd_opp_14_drift",
    "hd_opp_15_drift",
    "hd_opp_2_drift",
    "hd_opp_3_drift",
    "hd_opp_4_drift",
    "hd_opp_5_drift",
    "hd_opp_6_drift",
    "hd_opp_7_drift",
    "hd_opp_8_drift",
    "hd_opp_9_drift",

    // hd_grip
    "hd_opp_1_grip",
    "hd_opp_10_grip",
    "hd_opp_11_grip",
    "hd_opp_12_grip",
    "hd_opp_13_grip",
    "hd_opp_14_grip",
    "hd_opp_15_grip",
    "hd_opp_2_grip",
    "hd_opp_3_grip",
    "hd_opp_4_grip",
    "hd_opp_5_grip",
    "hd_opp_6_grip",
    "hd_opp_7_grip",
    "hd_opp_8_grip",
    "hd_opp_9_grip",

    // hd_sc
    "hd_opp_1_sc",
    "hd_opp_10_sc",
    "hd_opp_11_sc",
    "hd_opp_12_sc",
    "hd_opp_13_sc",
    "hd_opp_14_sc",
    "hd_opp_15_sc",
    "hd_opp_2_sc",
    "hd_opp_3_sc",
    "hd_opp_4_sc",
    "hd_opp_5_sc",
    "hd_opp_6_sc",
    "hd_opp_7_sc",
    "hd_opp_8_sc",
    "hd_opp_9_sc",
    // opp_drag
    "opp_0_drag",
    "opp_1_drag",
    "opp_10_drag",
    "opp_11_drag",
    "opp_12_drag",
    "opp_13_drag",
    "opp_14_drag",
    "opp_2_drag",
    "opp_20_drag",
    "opp_21_drag",
    "opp_22_drag",
    "opp_23_drag",
    "opp_24_drag",
    "opp_25_drag",
    "opp_26_drag",
    "opp_27_drag",
    "opp_28_drag",
    "opp_29_drag",
    "opp_3_drag",
    "opp_30_drag",
    "opp_31_drag",
    "opp_32_drag",
    "opp_33_drag",
    "opp_34_drag",
    "opp_4_drag",
    "opp_41_drag",
    "opp_42_drag",
    "opp_43_drag",
    "opp_44_drag",
    "opp_45_drag",
    "opp_46_drag",
    "opp_47_drag",
    "opp_48_drag",
    "opp_49_drag",
    "opp_5_drag",
    "opp_50_drag",
    "opp_51_drag",
    "opp_52_drag",
    "opp_53_drag",
    "opp_54_drag",
    "opp_6_drag",
    "opp_7_drag",
    "opp_8_drag",
    "opp_9_drag",

    // opp_drift
    "opp_0_drift",
    "opp_1_drift",
    "opp_10_drift",
    "opp_11_drift",
    "opp_12_drift",
    "opp_13_drift",
    "opp_14_drift",
    "opp_2_drift",
    "opp_20_drift",
    "opp_21_drift",
    "opp_22_drift",
    "opp_23_drift",
    "opp_24_drift",
    "opp_25_drift",
    "opp_26_drift",
    "opp_27_drift",
    "opp_28_drift",
    "opp_29_drift",
    "opp_3_drift",
    "opp_30_drift",
    "opp_31_drift",
    "opp_32_drift",
    "opp_33_drift",
    "opp_34_drift",
    "opp_4_drift",
    "opp_41_drift",
    "opp_42_drift",
    "opp_43_drift",
    "opp_44_drift",
    "opp_45_drift",
    "opp_46_drift",
    "opp_47_drift",
    "opp_48_drift",
    "opp_49_drift",
    "opp_5_drift",
    "opp_50_drift",
    "opp_51_drift",
    "opp_52_drift",
    "opp_53_drift",
    "opp_54_drift",
    "opp_6_drift",
    "opp_7_drift",
    "opp_8_drift",
    "opp_9_drift",

    // opp_grip
    "opp_0_grip",
    "opp_1_grip",
    "opp_10_grip",
    "opp_11_grip",
    "opp_12_grip",
    "opp_13_grip",
    "opp_14_grip",
    "opp_2_grip",
    "opp_20_grip",
    "opp_21_grip",
    "opp_22_grip",
    "opp_23_grip",
    "opp_24_grip",
    "opp_25_grip",
    "opp_26_grip",
    "opp_27_grip",
    "opp_28_grip",
    "opp_29_grip",
    "opp_3_grip",
    "opp_30_grip",
    "opp_31_grip",
    "opp_32_grip",
    "opp_33_grip",
    "opp_34_grip",
    "opp_4_grip",
    "opp_41_grip",
    "opp_42_grip",
    "opp_43_grip",
    "opp_44_grip",
    "opp_45_grip",
    "opp_46_grip",
    "opp_47_grip",
    "opp_48_grip",
    "opp_49_grip",
    "opp_5_grip",
    "opp_50_grip",
    "opp_51_grip",
    "opp_52_grip",
    "opp_53_grip",
    "opp_54_grip",
    "opp_6_grip",
    "opp_7_grip",
    "opp_8_grip",
    "opp_9_grip",

    // opp_sc
    "opp_0_sc",
    "opp_1_sc",
    "opp_10_sc",
    "opp_11_sc",
    "opp_12_sc",
    "opp_13_sc",
    "opp_14_sc",
    "opp_2_sc",
    "opp_20_sc",
    "opp_21_sc",
    "opp_22_sc",
    "opp_23_sc",
    "opp_24_sc",
    "opp_25_sc",
    "opp_26_sc",
    "opp_27_sc",
    "opp_28_sc",
    "opp_29_sc",
    "opp_3_sc",
    "opp_30_sc",
    "opp_31_sc",
    "opp_32_sc",
    "opp_33_sc",
    "opp_34_sc",
    "opp_4_sc",
    "opp_41_sc",
    "opp_42_sc",
    "opp_43_sc",
    "opp_44_sc",
    "opp_45_sc",
    "opp_46_sc",
    "opp_47_sc",
    "opp_48_sc",
    "opp_49_sc",
    "opp_5_sc",
    "opp_50_sc",
    "opp_51_sc",
    "opp_52_sc",
    "opp_53_sc",
    "opp_54_sc",
    "opp_6_sc",
    "opp_7_sc",
    "opp_8_sc",
    "opp_9_sc",
    // player_presets
    "player_ch_t1_ptl_grip_civichb",
    "player_ch_t1_ptl_grip_mustgt",
    "player_d_day",

    // screenshots
    "screenshot_240sx_grip_1",
    "screenshot_911t_grip_1",
    "screenshot_ae86_grip_1",
    "screenshot_corvette_grip_1",
    "screenshot_cuda_grip_1",
    "screenshot_elise_grip_1",
    "screenshot_g35_grip_1",
    "screenshot_gt500_grip_1",
    "screenshot_is350_grip_1",
    "screenshot_kobel_s15_grip_1",
    "screenshot_mustang_grip_1",
    "screenshot_rsx_grip_1",
    "screenshot_rx7_grip_1",
    "screenshot_rx8_grip_1",
    "screenshot_s15_grip_1",
    "screenshot_skyline_grip_1",
    "screenshot_supra_grip_1",

    // webtool
    "webtool_focus_1",
    "webtool_focus_2",
    "webtool_focus_3",
    "webtool_rsx_1",
    "webtool_rsx_2",
    "webtool_rsx_3",
    "webtool_sti_1",
    "webtool_sti_2",
    "webtool_sti_3",
    "webtool_ttn_1",
    "webtool_ttn_2",
    "webtool_ttn_3"
}; */
    }
}
