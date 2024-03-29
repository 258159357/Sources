﻿// Decompiled with JetBrains decompiler
// Type: Terraria.ID.NPCID
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: C2103E81-0935-4BEA-9E98-4159FC80C2BB
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.ID
{
  public class NPCID
  {
    private static readonly int[] NetIdMap = new int[65]
    {
      81,
      81,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      6,
      6,
      31,
      31,
      77,
      42,
      42,
      176,
      176,
      176,
      176,
      173,
      173,
      183,
      183,
      3,
      3,
      132,
      132,
      186,
      186,
      187,
      187,
      188,
      188,
      189,
      189,
      190,
      191,
      192,
      193,
      194,
      2,
      200,
      200,
      21,
      21,
      201,
      201,
      202,
      202,
      203,
      203,
      223,
      223,
      231,
      231,
      232,
      232,
      233,
      233,
      234,
      234,
      235,
      235
    };
    private static readonly Dictionary<string, int> LegacyNameToIdMap = new Dictionary<string, int>()
    {
      {
        "Slimeling",
        -1
      },
      {
        "Slimer2",
        -2
      },
      {
        "Green Slime",
        -3
      },
      {
        "Pinky",
        -4
      },
      {
        "Baby Slime",
        -5
      },
      {
        "Black Slime",
        -6
      },
      {
        "Purple Slime",
        -7
      },
      {
        "Red Slime",
        -8
      },
      {
        "Yellow Slime",
        -9
      },
      {
        "Jungle Slime",
        -10
      },
      {
        "Little Eater",
        -11
      },
      {
        "Big Eater",
        -12
      },
      {
        "Short Bones",
        -13
      },
      {
        "Big Boned",
        -14
      },
      {
        "Heavy Skeleton",
        -15
      },
      {
        "Little Stinger",
        -16
      },
      {
        "Big Stinger",
        -17
      },
      {
        "Tiny Moss Hornet",
        -18
      },
      {
        "Little Moss Hornet",
        -19
      },
      {
        "Big Moss Hornet",
        -20
      },
      {
        "Giant Moss Hornet",
        -21
      },
      {
        "Little Crimera",
        -22
      },
      {
        "Big Crimera",
        -23
      },
      {
        "Little Crimslime",
        -24
      },
      {
        "Big Crimslime",
        -25
      },
      {
        "Small Zombie",
        -26
      },
      {
        "Big Zombie",
        -27
      },
      {
        "Small Bald Zombie",
        -28
      },
      {
        "Big Bald Zombie",
        -29
      },
      {
        "Small Pincushion Zombie",
        -30
      },
      {
        "Big Pincushion Zombie",
        -31
      },
      {
        "Small Slimed Zombie",
        -32
      },
      {
        "Big Slimed Zombie",
        -33
      },
      {
        "Small Swamp Zombie",
        -34
      },
      {
        "Big Swamp Zombie",
        -35
      },
      {
        "Small Twiggy Zombie",
        -36
      },
      {
        "Big Twiggy Zombie",
        -37
      },
      {
        "Cataract Eye 2",
        -38
      },
      {
        "Sleepy Eye 2",
        -39
      },
      {
        "Dialated Eye 2",
        -40
      },
      {
        "Green Eye 2",
        -41
      },
      {
        "Purple Eye 2",
        -42
      },
      {
        "Demon Eye 2",
        -43
      },
      {
        "Small Female Zombie",
        -44
      },
      {
        "Big Female Zombie",
        -45
      },
      {
        "Small Skeleton",
        -46
      },
      {
        "Big Skeleton",
        -47
      },
      {
        "Small Headache Skeleton",
        -48
      },
      {
        "Big Headache Skeleton",
        -49
      },
      {
        "Small Misassembled Skeleton",
        -50
      },
      {
        "Big Misassembled Skeleton",
        -51
      },
      {
        "Small Pantless Skeleton",
        -52
      },
      {
        "Big Pantless Skeleton",
        -53
      },
      {
        "Small Rain Zombie",
        -54
      },
      {
        "Big Rain Zombie",
        -55
      },
      {
        "Little Hornet Fatty",
        -56
      },
      {
        "Big Hornet Fatty",
        -57
      },
      {
        "Little Hornet Honey",
        -58
      },
      {
        "Big Hornet Honey",
        -59
      },
      {
        "Little Hornet Leafy",
        -60
      },
      {
        "Big Hornet Leafy",
        -61
      },
      {
        "Little Hornet Spikey",
        -62
      },
      {
        "Big Hornet Spikey",
        -63
      },
      {
        "Little Hornet Stingy",
        -64
      },
      {
        "Big Hornet Stingy",
        -65
      },
      {
        "Blue Slime",
        1
      },
      {
        "Demon Eye",
        2
      },
      {
        "Zombie",
        3
      },
      {
        "Eye of Cthulhu",
        4
      },
      {
        "Servant of Cthulhu",
        5
      },
      {
        "Eater of Souls",
        6
      },
      {
        "Devourer",
        7
      },
      {
        "Giant Worm",
        10
      },
      {
        "Eater of Worlds",
        13
      },
      {
        "Mother Slime",
        16
      },
      {
        "Merchant",
        17
      },
      {
        "Nurse",
        18
      },
      {
        "Arms Dealer",
        19
      },
      {
        "Dryad",
        20
      },
      {
        "Skeleton",
        21
      },
      {
        "Guide",
        22
      },
      {
        "Meteor Head",
        23
      },
      {
        "Fire Imp",
        24
      },
      {
        "Burning Sphere",
        25
      },
      {
        "Goblin Peon",
        26
      },
      {
        "Goblin Thief",
        27
      },
      {
        "Goblin Warrior",
        28
      },
      {
        "Goblin Sorcerer",
        29
      },
      {
        "Chaos Ball",
        30
      },
      {
        "Angry Bones",
        31
      },
      {
        "Dark Caster",
        32
      },
      {
        "Water Sphere",
        33
      },
      {
        "Cursed Skull",
        34
      },
      {
        "Skeletron",
        35
      },
      {
        "Old Man",
        37
      },
      {
        "Demolitionist",
        38
      },
      {
        "Bone Serpent",
        39
      },
      {
        "Hornet",
        42
      },
      {
        "Man Eater",
        43
      },
      {
        "Undead Miner",
        44
      },
      {
        "Tim",
        45
      },
      {
        "Bunny",
        46
      },
      {
        "Corrupt Bunny",
        47
      },
      {
        "Harpy",
        48
      },
      {
        "Cave Bat",
        49
      },
      {
        "King Slime",
        50
      },
      {
        "Jungle Bat",
        51
      },
      {
        "Doctor Bones",
        52
      },
      {
        "The Groom",
        53
      },
      {
        "Clothier",
        54
      },
      {
        "Goldfish",
        55
      },
      {
        "Snatcher",
        56
      },
      {
        "Corrupt Goldfish",
        57
      },
      {
        "Piranha",
        58
      },
      {
        "Lava Slime",
        59
      },
      {
        "Hellbat",
        60
      },
      {
        "Vulture",
        61
      },
      {
        "Demon",
        62
      },
      {
        "Blue Jellyfish",
        63
      },
      {
        "Pink Jellyfish",
        64
      },
      {
        "Shark",
        65
      },
      {
        "Voodoo Demon",
        66
      },
      {
        "Crab",
        67
      },
      {
        "Dungeon Guardian",
        68
      },
      {
        "Antlion",
        69
      },
      {
        "Spike Ball",
        70
      },
      {
        "Dungeon Slime",
        71
      },
      {
        "Blazing Wheel",
        72
      },
      {
        "Goblin Scout",
        73
      },
      {
        "Bird",
        74
      },
      {
        "Pixie",
        75
      },
      {
        "Armored Skeleton",
        77
      },
      {
        "Mummy",
        78
      },
      {
        "Dark Mummy",
        79
      },
      {
        "Light Mummy",
        80
      },
      {
        "Corrupt Slime",
        81
      },
      {
        "Wraith",
        82
      },
      {
        "Cursed Hammer",
        83
      },
      {
        "Enchanted Sword",
        84
      },
      {
        "Mimic",
        85
      },
      {
        "Unicorn",
        86
      },
      {
        "Wyvern",
        87
      },
      {
        "Giant Bat",
        93
      },
      {
        "Corruptor",
        94
      },
      {
        "Digger",
        95
      },
      {
        "World Feeder",
        98
      },
      {
        "Clinger",
        101
      },
      {
        "Angler Fish",
        102
      },
      {
        "Green Jellyfish",
        103
      },
      {
        "Werewolf",
        104
      },
      {
        "Bound Goblin",
        105
      },
      {
        "Bound Wizard",
        106
      },
      {
        "Goblin Tinkerer",
        107
      },
      {
        "Wizard",
        108
      },
      {
        "Clown",
        109
      },
      {
        "Skeleton Archer",
        110
      },
      {
        "Goblin Archer",
        111
      },
      {
        "Vile Spit",
        112
      },
      {
        "Wall of Flesh",
        113
      },
      {
        "The Hungry",
        115
      },
      {
        "Leech",
        117
      },
      {
        "Chaos Elemental",
        120
      },
      {
        "Slimer",
        121
      },
      {
        "Gastropod",
        122
      },
      {
        "Bound Mechanic",
        123
      },
      {
        "Mechanic",
        124
      },
      {
        "Retinazer",
        125
      },
      {
        "Spazmatism",
        126
      },
      {
        "Skeletron Prime",
        (int) sbyte.MaxValue
      },
      {
        "Prime Cannon",
        128
      },
      {
        "Prime Saw",
        129
      },
      {
        "Prime Vice",
        130
      },
      {
        "Prime Laser",
        131
      },
      {
        "Wandering Eye",
        133
      },
      {
        "The Destroyer",
        134
      },
      {
        "Illuminant Bat",
        137
      },
      {
        "Illuminant Slime",
        138
      },
      {
        "Probe",
        139
      },
      {
        "Possessed Armor",
        140
      },
      {
        "Toxic Sludge",
        141
      },
      {
        "Santa Claus",
        142
      },
      {
        "Snowman Gangsta",
        143
      },
      {
        "Mister Stabby",
        144
      },
      {
        "Snow Balla",
        145
      },
      {
        "Ice Slime",
        147
      },
      {
        "Penguin",
        148
      },
      {
        "Ice Bat",
        150
      },
      {
        "Lava Bat",
        151
      },
      {
        "Giant Flying Fox",
        152
      },
      {
        "Giant Tortoise",
        153
      },
      {
        "Ice Tortoise",
        154
      },
      {
        "Wolf",
        155
      },
      {
        "Red Devil",
        156
      },
      {
        "Arapaima",
        157
      },
      {
        "Vampire",
        158
      },
      {
        "Truffle",
        160
      },
      {
        "Zombie Eskimo",
        161
      },
      {
        "Frankenstein",
        162
      },
      {
        "Black Recluse",
        163
      },
      {
        "Wall Creeper",
        164
      },
      {
        "Swamp Thing",
        166
      },
      {
        "Undead Viking",
        167
      },
      {
        "Corrupt Penguin",
        168
      },
      {
        "Ice Elemental",
        169
      },
      {
        "Pigron",
        170
      },
      {
        "Rune Wizard",
        172
      },
      {
        "Crimera",
        173
      },
      {
        "Herpling",
        174
      },
      {
        "Angry Trapper",
        175
      },
      {
        "Moss Hornet",
        176
      },
      {
        "Derpling",
        177
      },
      {
        "Steampunker",
        178
      },
      {
        "Crimson Axe",
        179
      },
      {
        "Face Monster",
        181
      },
      {
        "Floaty Gross",
        182
      },
      {
        "Crimslime",
        183
      },
      {
        "Spiked Ice Slime",
        184
      },
      {
        "Snow Flinx",
        185
      },
      {
        "Lost Girl",
        195
      },
      {
        "Nymph",
        196
      },
      {
        "Armored Viking",
        197
      },
      {
        "Lihzahrd",
        198
      },
      {
        "Spiked Jungle Slime",
        204
      },
      {
        "Moth",
        205
      },
      {
        "Icy Merman",
        206
      },
      {
        "Dye Trader",
        207
      },
      {
        "Party Girl",
        208
      },
      {
        "Cyborg",
        209
      },
      {
        "Bee",
        210
      },
      {
        "Pirate Deckhand",
        212
      },
      {
        "Pirate Corsair",
        213
      },
      {
        "Pirate Deadeye",
        214
      },
      {
        "Pirate Crossbower",
        215
      },
      {
        "Pirate Captain",
        216
      },
      {
        "Cochineal Beetle",
        217
      },
      {
        "Cyan Beetle",
        218
      },
      {
        "Lac Beetle",
        219
      },
      {
        "Sea Snail",
        220
      },
      {
        "Squid",
        221
      },
      {
        "Queen Bee",
        222
      },
      {
        "Raincoat Zombie",
        223
      },
      {
        "Flying Fish",
        224
      },
      {
        "Umbrella Slime",
        225
      },
      {
        "Flying Snake",
        226
      },
      {
        "Painter",
        227
      },
      {
        "Witch Doctor",
        228
      },
      {
        "Pirate",
        229
      },
      {
        "Jungle Creeper",
        236
      },
      {
        "Blood Crawler",
        239
      },
      {
        "Blood Feeder",
        241
      },
      {
        "Blood Jelly",
        242
      },
      {
        "Ice Golem",
        243
      },
      {
        "Rainbow Slime",
        244
      },
      {
        "Golem",
        245
      },
      {
        "Golem Head",
        246
      },
      {
        "Golem Fist",
        247
      },
      {
        "Angry Nimbus",
        250
      },
      {
        "Eyezor",
        251
      },
      {
        "Parrot",
        252
      },
      {
        "Reaper",
        253
      },
      {
        "Spore Zombie",
        254
      },
      {
        "Fungo Fish",
        256
      },
      {
        "Anomura Fungus",
        257
      },
      {
        "Mushi Ladybug",
        258
      },
      {
        "Fungi Bulb",
        259
      },
      {
        "Giant Fungi Bulb",
        260
      },
      {
        "Fungi Spore",
        261
      },
      {
        "Plantera",
        262
      },
      {
        "Plantera's Hook",
        263
      },
      {
        "Plantera's Tentacle",
        264
      },
      {
        "Spore",
        265
      },
      {
        "Brain of Cthulhu",
        266
      },
      {
        "Creeper",
        267
      },
      {
        "Ichor Sticker",
        268
      },
      {
        "Rusty Armored Bones",
        269
      },
      {
        "Blue Armored Bones",
        273
      },
      {
        "Hell Armored Bones",
        277
      },
      {
        "Ragged Caster",
        281
      },
      {
        "Necromancer",
        283
      },
      {
        "Diabolist",
        285
      },
      {
        "Bone Lee",
        287
      },
      {
        "Dungeon Spirit",
        288
      },
      {
        "Giant Cursed Skull",
        289
      },
      {
        "Paladin",
        290
      },
      {
        "Skeleton Sniper",
        291
      },
      {
        "Tactical Skeleton",
        292
      },
      {
        "Skeleton Commando",
        293
      },
      {
        "Blue Jay",
        297
      },
      {
        "Cardinal",
        298
      },
      {
        "Squirrel",
        299
      },
      {
        "Mouse",
        300
      },
      {
        "Raven",
        301
      },
      {
        "Slime",
        302
      },
      {
        "Hoppin' Jack",
        304
      },
      {
        "Scarecrow",
        305
      },
      {
        "Headless Horseman",
        315
      },
      {
        "Ghost",
        316
      },
      {
        "Mourning Wood",
        325
      },
      {
        "Splinterling",
        326
      },
      {
        "Pumpking",
        327
      },
      {
        "Hellhound",
        329
      },
      {
        "Poltergeist",
        330
      },
      {
        "Zombie Elf",
        338
      },
      {
        "Present Mimic",
        341
      },
      {
        "Gingerbread Man",
        342
      },
      {
        "Yeti",
        343
      },
      {
        "Everscream",
        344
      },
      {
        "Ice Queen",
        345
      },
      {
        "Santa",
        346
      },
      {
        "Elf Copter",
        347
      },
      {
        "Nutcracker",
        348
      },
      {
        "Elf Archer",
        350
      },
      {
        "Krampus",
        351
      },
      {
        "Flocko",
        352
      },
      {
        "Stylist",
        353
      },
      {
        "Webbed Stylist",
        354
      },
      {
        "Firefly",
        355
      },
      {
        "Butterfly",
        356
      },
      {
        "Worm",
        357
      },
      {
        "Lightning Bug",
        358
      },
      {
        "Snail",
        359
      },
      {
        "Glowing Snail",
        360
      },
      {
        "Frog",
        361
      },
      {
        "Duck",
        362
      },
      {
        "Scorpion",
        366
      },
      {
        "Traveling Merchant",
        368
      },
      {
        "Angler",
        369
      },
      {
        "Duke Fishron",
        370
      },
      {
        "Detonating Bubble",
        371
      },
      {
        "Sharkron",
        372
      },
      {
        "Truffle Worm",
        374
      },
      {
        "Sleeping Angler",
        376
      },
      {
        "Grasshopper",
        377
      },
      {
        "Chattering Teeth Bomb",
        378
      },
      {
        "Blue Cultist Archer",
        379
      },
      {
        "White Cultist Archer",
        380
      },
      {
        "Brain Scrambler",
        381
      },
      {
        "Ray Gunner",
        382
      },
      {
        "Martian Officer",
        383
      },
      {
        "Bubble Shield",
        384
      },
      {
        "Gray Grunt",
        385
      },
      {
        "Martian Engineer",
        386
      },
      {
        "Tesla Turret",
        387
      },
      {
        "Martian Drone",
        388
      },
      {
        "Gigazapper",
        389
      },
      {
        "Scutlix Gunner",
        390
      },
      {
        "Scutlix",
        391
      },
      {
        "Martian Saucer",
        392
      },
      {
        "Martian Saucer Turret",
        393
      },
      {
        "Martian Saucer Cannon",
        394
      },
      {
        "Moon Lord",
        396
      },
      {
        "Moon Lord's Hand",
        397
      },
      {
        "Moon Lord's Core",
        398
      },
      {
        "Martian Probe",
        399
      },
      {
        "Milkyway Weaver",
        402
      },
      {
        "Star Cell",
        405
      },
      {
        "Flow Invader",
        407
      },
      {
        "Twinkle Popper",
        409
      },
      {
        "Twinkle",
        410
      },
      {
        "Stargazer",
        411
      },
      {
        "Crawltipede",
        412
      },
      {
        "Drakomire",
        415
      },
      {
        "Drakomire Rider",
        416
      },
      {
        "Sroller",
        417
      },
      {
        "Corite",
        418
      },
      {
        "Selenian",
        419
      },
      {
        "Nebula Floater",
        420
      },
      {
        "Brain Suckler",
        421
      },
      {
        "Vortex Pillar",
        422
      },
      {
        "Evolution Beast",
        423
      },
      {
        "Predictor",
        424
      },
      {
        "Storm Diver",
        425
      },
      {
        "Alien Queen",
        426
      },
      {
        "Alien Hornet",
        427
      },
      {
        "Alien Larva",
        428
      },
      {
        "Vortexian",
        429
      },
      {
        "Mysterious Tablet",
        437
      },
      {
        "Lunatic Devote",
        438
      },
      {
        "Lunatic Cultist",
        439
      },
      {
        "Tax Collector",
        441
      },
      {
        "Gold Bird",
        442
      },
      {
        "Gold Bunny",
        443
      },
      {
        "Gold Butterfly",
        444
      },
      {
        "Gold Frog",
        445
      },
      {
        "Gold Grasshopper",
        446
      },
      {
        "Gold Mouse",
        447
      },
      {
        "Gold Worm",
        448
      },
      {
        "Phantasm Dragon",
        454
      },
      {
        "Butcher",
        460
      },
      {
        "Creature from the Deep",
        461
      },
      {
        "Fritz",
        462
      },
      {
        "Nailhead",
        463
      },
      {
        "Crimtane Bunny",
        464
      },
      {
        "Crimtane Goldfish",
        465
      },
      {
        "Psycho",
        466
      },
      {
        "Deadly Sphere",
        467
      },
      {
        "Dr. Man Fly",
        468
      },
      {
        "The Possessed",
        469
      },
      {
        "Vicious Penguin",
        470
      },
      {
        "Goblin Summoner",
        471
      },
      {
        "Shadowflame Apparation",
        472
      },
      {
        "Corrupt Mimic",
        473
      },
      {
        "Crimson Mimic",
        474
      },
      {
        "Hallowed Mimic",
        475
      },
      {
        "Jungle Mimic",
        476
      },
      {
        "Mothron",
        477
      },
      {
        "Mothron Egg",
        478
      },
      {
        "Baby Mothron",
        479
      },
      {
        "Medusa",
        480
      },
      {
        "Hoplite",
        481
      },
      {
        "Granite Golem",
        482
      },
      {
        "Granite Elemental",
        483
      },
      {
        "Enchanted Nightcrawler",
        484
      },
      {
        "Grubby",
        485
      },
      {
        "Sluggy",
        486
      },
      {
        "Buggy",
        487
      },
      {
        "Target Dummy",
        488
      },
      {
        "Blood Zombie",
        489
      },
      {
        "Drippler",
        490
      },
      {
        "Stardust Pillar",
        493
      },
      {
        "Crawdad",
        494
      },
      {
        "Giant Shelly",
        496
      },
      {
        "Salamander",
        498
      },
      {
        "Nebula Pillar",
        507
      },
      {
        "Antlion Charger",
        508
      },
      {
        "Antlion Swarmer",
        509
      },
      {
        "Dune Splicer",
        510
      },
      {
        "Tomb Crawler",
        513
      },
      {
        "Solar Flare",
        516
      },
      {
        "Solar Pillar",
        517
      },
      {
        "Drakanian",
        518
      },
      {
        "Solar Fragment",
        519
      },
      {
        "Martian Walker",
        520
      },
      {
        "Ancient Vision",
        521
      },
      {
        "Ancient Light",
        522
      },
      {
        "Ancient Doom",
        523
      },
      {
        "Ghoul",
        524
      },
      {
        "Vile Ghoul",
        525
      },
      {
        "Tainted Ghoul",
        526
      },
      {
        "Dreamer Ghoul",
        527
      },
      {
        "Lamia",
        528
      },
      {
        "Sand Poacher",
        530
      },
      {
        "Basilisk",
        532
      },
      {
        "Desert Spirit",
        533
      },
      {
        "Tortured Soul",
        534
      },
      {
        "Spiked Slime",
        535
      },
      {
        "The Bride",
        536
      },
      {
        "Sand Slime",
        537
      },
      {
        "Red Squirrel",
        538
      },
      {
        "Gold Squirrel",
        539
      },
      {
        "Sand Elemental",
        541
      },
      {
        "Sand Shark",
        542
      },
      {
        "Bone Biter",
        543
      },
      {
        "Flesh Reaver",
        544
      },
      {
        "Crystal Thresher",
        545
      },
      {
        "Angry Tumbler",
        546
      },
      {
        "???",
        547
      },
      {
        "Eternia Crystal",
        548
      },
      {
        "Mysterious Portal",
        549
      },
      {
        "Tavernkeep",
        550
      },
      {
        "Betsy",
        551
      },
      {
        "Etherian Goblin",
        552
      },
      {
        "Etherian Goblin Bomber",
        555
      },
      {
        "Etherian Wyvern",
        558
      },
      {
        "Etherian Javelin Thrower",
        561
      },
      {
        "Dark Mage",
        564
      },
      {
        "Old One's Skeleton",
        566
      },
      {
        "Wither Beast",
        568
      },
      {
        "Drakin",
        570
      },
      {
        "Kobold",
        572
      },
      {
        "Kobold Glider",
        574
      },
      {
        "Ogre",
        576
      },
      {
        "Etherian Lightning Bug",
        578
      }
    };
    public const short BigHornetStingy = -65;
    public const short LittleHornetStingy = -64;
    public const short BigHornetSpikey = -63;
    public const short LittleHornetSpikey = -62;
    public const short BigHornetLeafy = -61;
    public const short LittleHornetLeafy = -60;
    public const short BigHornetHoney = -59;
    public const short LittleHornetHoney = -58;
    public const short BigHornetFatty = -57;
    public const short LittleHornetFatty = -56;
    public const short BigRainZombie = -55;
    public const short SmallRainZombie = -54;
    public const short BigPantlessSkeleton = -53;
    public const short SmallPantlessSkeleton = -52;
    public const short BigMisassembledSkeleton = -51;
    public const short SmallMisassembledSkeleton = -50;
    public const short BigHeadacheSkeleton = -49;
    public const short SmallHeadacheSkeleton = -48;
    public const short BigSkeleton = -47;
    public const short SmallSkeleton = -46;
    public const short BigFemaleZombie = -45;
    public const short SmallFemaleZombie = -44;
    public const short DemonEye2 = -43;
    public const short PurpleEye2 = -42;
    public const short GreenEye2 = -41;
    public const short DialatedEye2 = -40;
    public const short SleepyEye2 = -39;
    public const short CataractEye2 = -38;
    public const short BigTwiggyZombie = -37;
    public const short SmallTwiggyZombie = -36;
    public const short BigSwampZombie = -35;
    public const short SmallSwampZombie = -34;
    public const short BigSlimedZombie = -33;
    public const short SmallSlimedZombie = -32;
    public const short BigPincushionZombie = -31;
    public const short SmallPincushionZombie = -30;
    public const short BigBaldZombie = -29;
    public const short SmallBaldZombie = -28;
    public const short BigZombie = -27;
    public const short SmallZombie = -26;
    public const short BigCrimslime = -25;
    public const short LittleCrimslime = -24;
    public const short BigCrimera = -23;
    public const short LittleCrimera = -22;
    public const short GiantMossHornet = -21;
    public const short BigMossHornet = -20;
    public const short LittleMossHornet = -19;
    public const short TinyMossHornet = -18;
    public const short BigStinger = -17;
    public const short LittleStinger = -16;
    public const short HeavySkeleton = -15;
    public const short BigBoned = -14;
    public const short ShortBones = -13;
    public const short BigEater = -12;
    public const short LittleEater = -11;
    public const short JungleSlime = -10;
    public const short YellowSlime = -9;
    public const short RedSlime = -8;
    public const short PurpleSlime = -7;
    public const short BlackSlime = -6;
    public const short BabySlime = -5;
    public const short Pinky = -4;
    public const short GreenSlime = -3;
    public const short Slimer2 = -2;
    public const short Slimeling = -1;
    public const short None = 0;
    public const short BlueSlime = 1;
    public const short DemonEye = 2;
    public const short Zombie = 3;
    public const short EyeofCthulhu = 4;
    public const short ServantofCthulhu = 5;
    public const short EaterofSouls = 6;
    public const short DevourerHead = 7;
    public const short DevourerBody = 8;
    public const short DevourerTail = 9;
    public const short GiantWormHead = 10;
    public const short GiantWormBody = 11;
    public const short GiantWormTail = 12;
    public const short EaterofWorldsHead = 13;
    public const short EaterofWorldsBody = 14;
    public const short EaterofWorldsTail = 15;
    public const short MotherSlime = 16;
    public const short Merchant = 17;
    public const short Nurse = 18;
    public const short ArmsDealer = 19;
    public const short Dryad = 20;
    public const short Skeleton = 21;
    public const short Guide = 22;
    public const short MeteorHead = 23;
    public const short FireImp = 24;
    public const short BurningSphere = 25;
    public const short GoblinPeon = 26;
    public const short GoblinThief = 27;
    public const short GoblinWarrior = 28;
    public const short GoblinSorcerer = 29;
    public const short ChaosBall = 30;
    public const short AngryBones = 31;
    public const short DarkCaster = 32;
    public const short WaterSphere = 33;
    public const short CursedSkull = 34;
    public const short SkeletronHead = 35;
    public const short SkeletronHand = 36;
    public const short OldMan = 37;
    public const short Demolitionist = 38;
    public const short BoneSerpentHead = 39;
    public const short BoneSerpentBody = 40;
    public const short BoneSerpentTail = 41;
    public const short Hornet = 42;
    public const short ManEater = 43;
    public const short UndeadMiner = 44;
    public const short Tim = 45;
    public const short Bunny = 46;
    public const short CorruptBunny = 47;
    public const short Harpy = 48;
    public const short CaveBat = 49;
    public const short KingSlime = 50;
    public const short JungleBat = 51;
    public const short DoctorBones = 52;
    public const short TheGroom = 53;
    public const short Clothier = 54;
    public const short Goldfish = 55;
    public const short Snatcher = 56;
    public const short CorruptGoldfish = 57;
    public const short Piranha = 58;
    public const short LavaSlime = 59;
    public const short Hellbat = 60;
    public const short Vulture = 61;
    public const short Demon = 62;
    public const short BlueJellyfish = 63;
    public const short PinkJellyfish = 64;
    public const short Shark = 65;
    public const short VoodooDemon = 66;
    public const short Crab = 67;
    public const short DungeonGuardian = 68;
    public const short Antlion = 69;
    public const short SpikeBall = 70;
    public const short DungeonSlime = 71;
    public const short BlazingWheel = 72;
    public const short GoblinScout = 73;
    public const short Bird = 74;
    public const short Pixie = 75;
    public const short None2 = 76;
    public const short ArmoredSkeleton = 77;
    public const short Mummy = 78;
    public const short DarkMummy = 79;
    public const short LightMummy = 80;
    public const short CorruptSlime = 81;
    public const short Wraith = 82;
    public const short CursedHammer = 83;
    public const short EnchantedSword = 84;
    public const short Mimic = 85;
    public const short Unicorn = 86;
    public const short WyvernHead = 87;
    public const short WyvernLegs = 88;
    public const short WyvernBody = 89;
    public const short WyvernBody2 = 90;
    public const short WyvernBody3 = 91;
    public const short WyvernTail = 92;
    public const short GiantBat = 93;
    public const short Corruptor = 94;
    public const short DiggerHead = 95;
    public const short DiggerBody = 96;
    public const short DiggerTail = 97;
    public const short SeekerHead = 98;
    public const short SeekerBody = 99;
    public const short SeekerTail = 100;
    public const short Clinger = 101;
    public const short AnglerFish = 102;
    public const short GreenJellyfish = 103;
    public const short Werewolf = 104;
    public const short BoundGoblin = 105;
    public const short BoundWizard = 106;
    public const short GoblinTinkerer = 107;
    public const short Wizard = 108;
    public const short Clown = 109;
    public const short SkeletonArcher = 110;
    public const short GoblinArcher = 111;
    public const short VileSpit = 112;
    public const short WallofFlesh = 113;
    public const short WallofFleshEye = 114;
    public const short TheHungry = 115;
    public const short TheHungryII = 116;
    public const short LeechHead = 117;
    public const short LeechBody = 118;
    public const short LeechTail = 119;
    public const short ChaosElemental = 120;
    public const short Slimer = 121;
    public const short Gastropod = 122;
    public const short BoundMechanic = 123;
    public const short Mechanic = 124;
    public const short Retinazer = 125;
    public const short Spazmatism = 126;
    public const short SkeletronPrime = 127;
    public const short PrimeCannon = 128;
    public const short PrimeSaw = 129;
    public const short PrimeVice = 130;
    public const short PrimeLaser = 131;
    public const short BaldZombie = 132;
    public const short WanderingEye = 133;
    public const short TheDestroyer = 134;
    public const short TheDestroyerBody = 135;
    public const short TheDestroyerTail = 136;
    public const short IlluminantBat = 137;
    public const short IlluminantSlime = 138;
    public const short Probe = 139;
    public const short PossessedArmor = 140;
    public const short ToxicSludge = 141;
    public const short SantaClaus = 142;
    public const short SnowmanGangsta = 143;
    public const short MisterStabby = 144;
    public const short SnowBalla = 145;
    public const short None3 = 146;
    public const short IceSlime = 147;
    public const short Penguin = 148;
    public const short PenguinBlack = 149;
    public const short IceBat = 150;
    public const short Lavabat = 151;
    public const short GiantFlyingFox = 152;
    public const short GiantTortoise = 153;
    public const short IceTortoise = 154;
    public const short Wolf = 155;
    public const short RedDevil = 156;
    public const short Arapaima = 157;
    public const short VampireBat = 158;
    public const short Vampire = 159;
    public const short Truffle = 160;
    public const short ZombieEskimo = 161;
    public const short Frankenstein = 162;
    public const short BlackRecluse = 163;
    public const short WallCreeper = 164;
    public const short WallCreeperWall = 165;
    public const short SwampThing = 166;
    public const short UndeadViking = 167;
    public const short CorruptPenguin = 168;
    public const short IceElemental = 169;
    public const short PigronCorruption = 170;
    public const short PigronHallow = 171;
    public const short RuneWizard = 172;
    public const short Crimera = 173;
    public const short Herpling = 174;
    public const short AngryTrapper = 175;
    public const short MossHornet = 176;
    public const short Derpling = 177;
    public const short Steampunker = 178;
    public const short CrimsonAxe = 179;
    public const short PigronCrimson = 180;
    public const short FaceMonster = 181;
    public const short FloatyGross = 182;
    public const short Crimslime = 183;
    public const short SpikedIceSlime = 184;
    public const short SnowFlinx = 185;
    public const short PincushionZombie = 186;
    public const short SlimedZombie = 187;
    public const short SwampZombie = 188;
    public const short TwiggyZombie = 189;
    public const short CataractEye = 190;
    public const short SleepyEye = 191;
    public const short DialatedEye = 192;
    public const short GreenEye = 193;
    public const short PurpleEye = 194;
    public const short LostGirl = 195;
    public const short Nymph = 196;
    public const short ArmoredViking = 197;
    public const short Lihzahrd = 198;
    public const short LihzahrdCrawler = 199;
    public const short FemaleZombie = 200;
    public const short HeadacheSkeleton = 201;
    public const short MisassembledSkeleton = 202;
    public const short PantlessSkeleton = 203;
    public const short SpikedJungleSlime = 204;
    public const short Moth = 205;
    public const short IcyMerman = 206;
    public const short DyeTrader = 207;
    public const short PartyGirl = 208;
    public const short Cyborg = 209;
    public const short Bee = 210;
    public const short BeeSmall = 211;
    public const short PirateDeckhand = 212;
    public const short PirateCorsair = 213;
    public const short PirateDeadeye = 214;
    public const short PirateCrossbower = 215;
    public const short PirateCaptain = 216;
    public const short CochinealBeetle = 217;
    public const short CyanBeetle = 218;
    public const short LacBeetle = 219;
    public const short SeaSnail = 220;
    public const short Squid = 221;
    public const short QueenBee = 222;
    public const short ZombieRaincoat = 223;
    public const short FlyingFish = 224;
    public const short UmbrellaSlime = 225;
    public const short FlyingSnake = 226;
    public const short Painter = 227;
    public const short WitchDoctor = 228;
    public const short Pirate = 229;
    public const short GoldfishWalker = 230;
    public const short HornetFatty = 231;
    public const short HornetHoney = 232;
    public const short HornetLeafy = 233;
    public const short HornetSpikey = 234;
    public const short HornetStingy = 235;
    public const short JungleCreeper = 236;
    public const short JungleCreeperWall = 237;
    public const short BlackRecluseWall = 238;
    public const short BloodCrawler = 239;
    public const short BloodCrawlerWall = 240;
    public const short BloodFeeder = 241;
    public const short BloodJelly = 242;
    public const short IceGolem = 243;
    public const short RainbowSlime = 244;
    public const short Golem = 245;
    public const short GolemHead = 246;
    public const short GolemFistLeft = 247;
    public const short GolemFistRight = 248;
    public const short GolemHeadFree = 249;
    public const short AngryNimbus = 250;
    public const short Eyezor = 251;
    public const short Parrot = 252;
    public const short Reaper = 253;
    public const short ZombieMushroom = 254;
    public const short ZombieMushroomHat = 255;
    public const short FungoFish = 256;
    public const short AnomuraFungus = 257;
    public const short MushiLadybug = 258;
    public const short FungiBulb = 259;
    public const short GiantFungiBulb = 260;
    public const short FungiSpore = 261;
    public const short Plantera = 262;
    public const short PlanterasHook = 263;
    public const short PlanterasTentacle = 264;
    public const short Spore = 265;
    public const short BrainofCthulhu = 266;
    public const short Creeper = 267;
    public const short IchorSticker = 268;
    public const short RustyArmoredBonesAxe = 269;
    public const short RustyArmoredBonesFlail = 270;
    public const short RustyArmoredBonesSword = 271;
    public const short RustyArmoredBonesSwordNoArmor = 272;
    public const short BlueArmoredBones = 273;
    public const short BlueArmoredBonesMace = 274;
    public const short BlueArmoredBonesNoPants = 275;
    public const short BlueArmoredBonesSword = 276;
    public const short HellArmoredBones = 277;
    public const short HellArmoredBonesSpikeShield = 278;
    public const short HellArmoredBonesMace = 279;
    public const short HellArmoredBonesSword = 280;
    public const short RaggedCaster = 281;
    public const short RaggedCasterOpenCoat = 282;
    public const short Necromancer = 283;
    public const short NecromancerArmored = 284;
    public const short DiabolistRed = 285;
    public const short DiabolistWhite = 286;
    public const short BoneLee = 287;
    public const short DungeonSpirit = 288;
    public const short GiantCursedSkull = 289;
    public const short Paladin = 290;
    public const short SkeletonSniper = 291;
    public const short TacticalSkeleton = 292;
    public const short SkeletonCommando = 293;
    public const short AngryBonesBig = 294;
    public const short AngryBonesBigMuscle = 295;
    public const short AngryBonesBigHelmet = 296;
    public const short BirdBlue = 297;
    public const short BirdRed = 298;
    public const short Squirrel = 299;
    public const short Mouse = 300;
    public const short Raven = 301;
    public const short SlimeMasked = 302;
    public const short BunnySlimed = 303;
    public const short HoppinJack = 304;
    public const short Scarecrow1 = 305;
    public const short Scarecrow2 = 306;
    public const short Scarecrow3 = 307;
    public const short Scarecrow4 = 308;
    public const short Scarecrow5 = 309;
    public const short Scarecrow6 = 310;
    public const short Scarecrow7 = 311;
    public const short Scarecrow8 = 312;
    public const short Scarecrow9 = 313;
    public const short Scarecrow10 = 314;
    public const short HeadlessHorseman = 315;
    public const short Ghost = 316;
    public const short DemonEyeOwl = 317;
    public const short DemonEyeSpaceship = 318;
    public const short ZombieDoctor = 319;
    public const short ZombieSuperman = 320;
    public const short ZombiePixie = 321;
    public const short SkeletonTopHat = 322;
    public const short SkeletonAstonaut = 323;
    public const short SkeletonAlien = 324;
    public const short MourningWood = 325;
    public const short Splinterling = 326;
    public const short Pumpking = 327;
    public const short PumpkingBlade = 328;
    public const short Hellhound = 329;
    public const short Poltergeist = 330;
    public const short ZombieXmas = 331;
    public const short ZombieSweater = 332;
    public const short SlimeRibbonWhite = 333;
    public const short SlimeRibbonYellow = 334;
    public const short SlimeRibbonGreen = 335;
    public const short SlimeRibbonRed = 336;
    public const short BunnyXmas = 337;
    public const short ZombieElf = 338;
    public const short ZombieElfBeard = 339;
    public const short ZombieElfGirl = 340;
    public const short PresentMimic = 341;
    public const short GingerbreadMan = 342;
    public const short Yeti = 343;
    public const short Everscream = 344;
    public const short IceQueen = 345;
    public const short SantaNK1 = 346;
    public const short ElfCopter = 347;
    public const short Nutcracker = 348;
    public const short NutcrackerSpinning = 349;
    public const short ElfArcher = 350;
    public const short Krampus = 351;
    public const short Flocko = 352;
    public const short Stylist = 353;
    public const short WebbedStylist = 354;
    public const short Firefly = 355;
    public const short Butterfly = 356;
    public const short Worm = 357;
    public const short LightningBug = 358;
    public const short Snail = 359;
    public const short GlowingSnail = 360;
    public const short Frog = 361;
    public const short Duck = 362;
    public const short Duck2 = 363;
    public const short DuckWhite = 364;
    public const short DuckWhite2 = 365;
    public const short ScorpionBlack = 366;
    public const short Scorpion = 367;
    public const short TravellingMerchant = 368;
    public const short Angler = 369;
    public const short DukeFishron = 370;
    public const short DetonatingBubble = 371;
    public const short Sharkron = 372;
    public const short Sharkron2 = 373;
    public const short TruffleWorm = 374;
    public const short TruffleWormDigger = 375;
    public const short SleepingAngler = 376;
    public const short Grasshopper = 377;
    public const short ChatteringTeethBomb = 378;
    public const short CultistArcherBlue = 379;
    public const short CultistArcherWhite = 380;
    public const short BrainScrambler = 381;
    public const short RayGunner = 382;
    public const short MartianOfficer = 383;
    public const short ForceBubble = 384;
    public const short GrayGrunt = 385;
    public const short MartianEngineer = 386;
    public const short MartianTurret = 387;
    public const short MartianDrone = 388;
    public const short GigaZapper = 389;
    public const short ScutlixRider = 390;
    public const short Scutlix = 391;
    public const short MartianSaucer = 392;
    public const short MartianSaucerTurret = 393;
    public const short MartianSaucerCannon = 394;
    public const short MartianSaucerCore = 395;
    public const short MoonLordHead = 396;
    public const short MoonLordHand = 397;
    public const short MoonLordCore = 398;
    public const short MartianProbe = 399;
    public const short MoonLordFreeEye = 400;
    public const short MoonLordLeechBlob = 401;
    public const short StardustWormHead = 402;
    public const short StardustWormBody = 403;
    public const short StardustWormTail = 404;
    public const short StardustCellBig = 405;
    public const short StardustCellSmall = 406;
    public const short StardustJellyfishBig = 407;
    public const short StardustJellyfishSmall = 408;
    public const short StardustSpiderBig = 409;
    public const short StardustSpiderSmall = 410;
    public const short StardustSoldier = 411;
    public const short SolarCrawltipedeHead = 412;
    public const short SolarCrawltipedeBody = 413;
    public const short SolarCrawltipedeTail = 414;
    public const short SolarDrakomire = 415;
    public const short SolarDrakomireRider = 416;
    public const short SolarSroller = 417;
    public const short SolarCorite = 418;
    public const short SolarSolenian = 419;
    public const short NebulaBrain = 420;
    public const short NebulaHeadcrab = 421;
    public const short NebulaBeast = 423;
    public const short NebulaSoldier = 424;
    public const short VortexRifleman = 425;
    public const short VortexHornetQueen = 426;
    public const short VortexHornet = 427;
    public const short VortexLarva = 428;
    public const short VortexSoldier = 429;
    public const short ArmedZombie = 430;
    public const short ArmedZombieEskimo = 431;
    public const short ArmedZombiePincussion = 432;
    public const short ArmedZombieSlimed = 433;
    public const short ArmedZombieSwamp = 434;
    public const short ArmedZombieTwiggy = 435;
    public const short ArmedZombieCenx = 436;
    public const short CultistTablet = 437;
    public const short CultistDevote = 438;
    public const short CultistBoss = 439;
    public const short CultistBossClone = 440;
    public const short GoldBird = 442;
    public const short GoldBunny = 443;
    public const short GoldButterfly = 444;
    public const short GoldFrog = 445;
    public const short GoldGrasshopper = 446;
    public const short GoldMouse = 447;
    public const short GoldWorm = 448;
    public const short BoneThrowingSkeleton = 449;
    public const short BoneThrowingSkeleton2 = 450;
    public const short BoneThrowingSkeleton3 = 451;
    public const short BoneThrowingSkeleton4 = 452;
    public const short SkeletonMerchant = 453;
    public const short CultistDragonHead = 454;
    public const short CultistDragonBody1 = 455;
    public const short CultistDragonBody2 = 456;
    public const short CultistDragonBody3 = 457;
    public const short CultistDragonBody4 = 458;
    public const short CultistDragonTail = 459;
    public const short Butcher = 460;
    public const short CreatureFromTheDeep = 461;
    public const short Fritz = 462;
    public const short Nailhead = 463;
    public const short CrimsonBunny = 464;
    public const short CrimsonGoldfish = 465;
    public const short Psycho = 466;
    public const short DeadlySphere = 467;
    public const short DrManFly = 468;
    public const short ThePossessed = 469;
    public const short CrimsonPenguin = 470;
    public const short GoblinSummoner = 471;
    public const short ShadowFlameApparition = 472;
    public const short BigMimicCorruption = 473;
    public const short BigMimicCrimson = 474;
    public const short BigMimicHallow = 475;
    public const short BigMimicJungle = 476;
    public const short Mothron = 477;
    public const short MothronEgg = 478;
    public const short MothronSpawn = 479;
    public const short Medusa = 480;
    public const short GreekSkeleton = 481;
    public const short GraniteGolem = 482;
    public const short GraniteFlyer = 483;
    public const short EnchantedNightcrawler = 484;
    public const short Grubby = 485;
    public const short Sluggy = 486;
    public const short Buggy = 487;
    public const short TargetDummy = 488;
    public const short BloodZombie = 489;
    public const short Drippler = 490;
    public const short PirateShip = 491;
    public const short PirateShipCannon = 492;
    public const short LunarTowerStardust = 493;
    public const short Crawdad = 494;
    public const short Crawdad2 = 495;
    public const short GiantShelly = 496;
    public const short GiantShelly2 = 497;
    public const short Salamander = 498;
    public const short Salamander2 = 499;
    public const short Salamander3 = 500;
    public const short Salamander4 = 501;
    public const short Salamander5 = 502;
    public const short Salamander6 = 503;
    public const short Salamander7 = 504;
    public const short Salamander8 = 505;
    public const short Salamander9 = 506;
    public const short LunarTowerNebula = 507;
    public const short LunarTowerVortex = 422;
    public const short TaxCollector = 441;
    public const short WalkingAntlion = 508;
    public const short FlyingAntlion = 509;
    public const short DuneSplicerHead = 510;
    public const short DuneSplicerBody = 511;
    public const short DuneSplicerTail = 512;
    public const short TombCrawlerHead = 513;
    public const short TombCrawlerBody = 514;
    public const short TombCrawlerTail = 515;
    public const short SolarFlare = 516;
    public const short LunarTowerSolar = 517;
    public const short SolarSpearman = 518;
    public const short SolarGoop = 519;
    public const short MartianWalker = 520;
    public const short AncientCultistSquidhead = 521;
    public const short AncientLight = 522;
    public const short AncientDoom = 523;
    public const short DesertGhoul = 524;
    public const short DesertGhoulCorruption = 525;
    public const short DesertGhoulCrimson = 526;
    public const short DesertGhoulHallow = 527;
    public const short DesertLamiaLight = 528;
    public const short DesertLamiaDark = 529;
    public const short DesertScorpionWalk = 530;
    public const short DesertScorpionWall = 531;
    public const short DesertBeast = 532;
    public const short DesertDjinn = 533;
    public const short DemonTaxCollector = 534;
    public const short SlimeSpiked = 535;
    public const short TheBride = 536;
    public const short SandSlime = 537;
    public const short SquirrelRed = 538;
    public const short SquirrelGold = 539;
    public const short PartyBunny = 540;
    public const short SandElemental = 541;
    public const short SandShark = 542;
    public const short SandsharkCorrupt = 543;
    public const short SandsharkCrimson = 544;
    public const short SandsharkHallow = 545;
    public const short Tumbleweed = 546;
    public const short DD2AttackerTest = 547;
    public const short DD2EterniaCrystal = 548;
    public const short DD2LanePortal = 549;
    public const short DD2Bartender = 550;
    public const short DD2Betsy = 551;
    public const short DD2GoblinT1 = 552;
    public const short DD2GoblinT2 = 553;
    public const short DD2GoblinT3 = 554;
    public const short DD2GoblinBomberT1 = 555;
    public const short DD2GoblinBomberT2 = 556;
    public const short DD2GoblinBomberT3 = 557;
    public const short DD2WyvernT1 = 558;
    public const short DD2WyvernT2 = 559;
    public const short DD2WyvernT3 = 560;
    public const short DD2JavelinstT1 = 561;
    public const short DD2JavelinstT2 = 562;
    public const short DD2JavelinstT3 = 563;
    public const short DD2DarkMageT1 = 564;
    public const short DD2DarkMageT3 = 565;
    public const short DD2SkeletonT1 = 566;
    public const short DD2SkeletonT3 = 567;
    public const short DD2WitherBeastT2 = 568;
    public const short DD2WitherBeastT3 = 569;
    public const short DD2DrakinT2 = 570;
    public const short DD2DrakinT3 = 571;
    public const short DD2KoboldWalkerT2 = 572;
    public const short DD2KoboldWalkerT3 = 573;
    public const short DD2KoboldFlyerT2 = 574;
    public const short DD2KoboldFlyerT3 = 575;
    public const short DD2OgreT2 = 576;
    public const short DD2OgreT3 = 577;
    public const short DD2LightningBugT3 = 578;
    public const short BartenderUnconscious = 579;
    public const short Count = 580;

    public static int FromLegacyName(string name)
    {
      int num;
      if (NPCID.LegacyNameToIdMap.TryGetValue(name, out num))
        return num;
      return 0;
    }

    public static int FromNetId(int id)
    {
      if (id < 0)
        return NPCID.NetIdMap[-id - 1];
      return id;
    }

    public static class Sets
    {
      public static SetFactory Factory = new SetFactory(580);
      public static int[] TrailingMode = NPCID.Sets.Factory.CreateIntSet(-1, 439, 0, 440, 0, 370, 1, 372, 1, 373, 1, 396, 1, 400, 1, 401, 1, 473, 2, 474, 2, 475, 2, 476, 2, 4, 3, 471, 3, 477, 3, 479, 3, 120, 4, 137, 4, 138, 4, 94, 5, 125, 6, 126, 6, (int) sbyte.MaxValue, 6, 128, 6, 129, 6, 130, 6, 131, 6, 139, 6, 140, 6, 407, 6, 420, 6, 425, 6, 427, 6, 426, 6, 509, 6, 516, 6, 542, 6, 543, 6, 544, 6, 545, 6, 402, 7, 417, 7, 419, 7, 418, 7, 574, 7, 575, 7, 519, 7, 521, 7, 522, 7, 546, 7, 558, 7, 559, 7, 560, 7, 551, 7);
      public static bool[] BelongsToInvasionOldOnesArmy = NPCID.Sets.Factory.CreateBoolSet(552, 553, 554, 561, 562, 563, 555, 556, 557, 558, 559, 560, 576, 577, 568, 569, 566, 567, 570, 571, 572, 573, 548, 549, 564, 565, 574, 575, 551, 578);
      public static bool[] TeleportationImmune = NPCID.Sets.Factory.CreateBoolSet(552, 553, 554, 561, 562, 563, 555, 556, 557, 558, 559, 560, 576, 577, 568, 569, 566, 567, 570, 571, 572, 573, 548, 549, 564, 565, 574, 575, 551, 578);
      public static bool[] UsesNewTargetting = NPCID.Sets.Factory.CreateBoolSet(547, 552, 553, 554, 561, 562, 563, 555, 556, 557, 558, 559, 560, 576, 577, 568, 569, 566, 567, 570, 571, 572, 573, 564, 565, 574, 575, 551, 578);
      public static bool[] FighterUsesDD2PortalAppearEffect = NPCID.Sets.Factory.CreateBoolSet(552, 553, 554, 561, 562, 563, 555, 556, 557, 576, 577, 568, 569, 570, 571, 572, 573, 564, 565);
      public static float[] StatueSpawnedDropRarity = NPCID.Sets.Factory.CreateCustomSet<float>(-1f, (object) (short) 480, (object) 0.05f, (object) (short) 82, (object) 0.05f, (object) (short) 86, (object) 0.05f, (object) (short) 48, (object) 0.05f, (object) (short) 490, (object) 0.05f, (object) (short) 489, (object) 0.05f, (object) (short) 170, (object) 0.05f, (object) (short) 180, (object) 0.05f, (object) (short) 171, (object) 0.05f, (object) (short) 167, (object) 0.25f);
      public static bool[] NoEarlymodeLootWhenSpawnedFromStatue = NPCID.Sets.Factory.CreateBoolSet(480, 82, 86, 170, 180, 171);
      public static bool[] NeedsExpertScaling = NPCID.Sets.Factory.CreateBoolSet(25, 30, 33, 112, 261, 265, 371, 516, 519, 522, 397, 396, 398);
      public static bool[] ProjectileNPC = NPCID.Sets.Factory.CreateBoolSet(25, 30, 33, 112, 261, 265, 371, 516, 519, 522);
      public static bool[] SavesAndLoads = NPCID.Sets.Factory.CreateBoolSet(422, 507, 517, 493);
      public static int[] TrailCacheLength = NPCID.Sets.Factory.CreateIntSet(10, 402, 36, 519, 20, 522, 20);
      public static bool[] MPAllowedEnemies = NPCID.Sets.Factory.CreateBoolSet(4, 13, 50, 126, 125, 134, (int) sbyte.MaxValue, 128, 131, 129, 130, 222, 245, 266, 370);
      public static bool[] TownCritter = NPCID.Sets.Factory.CreateBoolSet(46, 148, 149, 230, 299, 300, 303, 337, 361, 362, 364, 366, 367, 443, 445, 447, 538, 539, 540);
      public static int[] HatOffsetY = NPCID.Sets.Factory.CreateIntSet(0, 227, 4, 107, 2, 108, 2, 229, 4, 17, 2, 38, 8, 160, -10, 208, 2, 142, 2, 124, 2, 453, 2, 37, 4, 54, 4, 209, 4, 369, 6, 441, 6, 353, -2, 550, -2);
      public static int[] FaceEmote = NPCID.Sets.Factory.CreateIntSet(0, 17, 101, 18, 102, 19, 103, 20, 104, 22, 105, 37, 106, 38, 107, 54, 108, 107, 109, 108, 110, 124, 111, 142, 112, 160, 113, 178, 114, 207, 115, 208, 116, 209, 117, 227, 118, 228, 119, 229, 120, 353, 121, 368, 122, 369, 123, 453, 124, 441, 125);
      public static int[] ExtraFramesCount = NPCID.Sets.Factory.CreateIntSet(0, 17, 9, 18, 9, 19, 9, 20, 7, 22, 10, 37, 5, 38, 9, 54, 7, 107, 9, 108, 7, 124, 9, 142, 9, 160, 7, 178, 9, 207, 9, 208, 9, 209, 10, 227, 9, 228, 10, 229, 10, 353, 9, 368, 10, 369, 9, 453, 9, 441, 9, 550, 9);
      public static int[] AttackFrameCount = NPCID.Sets.Factory.CreateIntSet(0, 17, 4, 18, 4, 19, 4, 20, 2, 22, 5, 37, 0, 38, 4, 54, 2, 107, 4, 108, 2, 124, 4, 142, 4, 160, 2, 178, 4, 207, 4, 208, 4, 209, 5, 227, 4, 228, 5, 229, 5, 353, 4, 368, 5, 369, 4, 453, 4, 441, 4, 550, 4);
      public static int[] DangerDetectRange = NPCID.Sets.Factory.CreateIntSet(-1, 38, 300, 17, 320, 107, 300, 19, 900, 22, 700, 124, 800, 228, 800, 178, 900, 18, 300, 229, 1000, 209, 1000, 54, 700, 108, 700, 160, 700, 20, 1200, 369, 300, 453, 300, 368, 900, 207, 60, 227, 800, 208, 400, 142, 500, 441, 50, 353, 60, 550, 120);
      public static int[] AttackTime = NPCID.Sets.Factory.CreateIntSet(-1, 38, 34, 17, 34, 107, 60, 19, 40, 22, 30, 124, 34, 228, 40, 178, 24, 18, 34, 229, 60, 209, 60, 54, 60, 108, 30, 160, 60, 20, 600, 369, 34, 453, 34, 368, 60, 207, 15, 227, 60, 208, 34, 142, 34, 441, 15, 353, 12, 550, 34);
      public static int[] AttackAverageChance = NPCID.Sets.Factory.CreateIntSet(1, 38, 40, 17, 30, 107, 60, 19, 30, 22, 30, 124, 30, 228, 50, 178, 50, 18, 60, 229, 40, 209, 30, 54, 30, 108, 30, 160, 60, 20, 60, 369, 50, 453, 30, 368, 40, 207, 1, 227, 30, 208, 50, 142, 50, 441, 1, 353, 1, 550, 40);
      public static int[] AttackType = NPCID.Sets.Factory.CreateIntSet(-1, 38, 0, 17, 0, 107, 0, 19, 1, 22, 1, 124, 0, 228, 1, 178, 1, 18, 0, 229, 1, 209, 1, 54, 2, 108, 2, 160, 2, 20, 2, 369, 0, 453, 0, 368, 1, 207, 3, 227, 1, 208, 0, 142, 0, 441, 3, 353, 3, 550, 0);
      public static int[] PrettySafe = NPCID.Sets.Factory.CreateIntSet(-1, 19, 300, 22, 200, 124, 200, 228, 300, 178, 300, 229, 300, 209, 300, 54, 100, 108, 100, 160, 100, 20, 200, 368, 200, 227, 200);
      public static Color[] MagicAuraColor = NPCID.Sets.Factory.CreateCustomSet<Color>(Color.White, (object) (short) 54, (object) new Color(100, 4, 227, (int) sbyte.MaxValue), (object) (short) 108, (object) new Color((int) byte.MaxValue, 80, 60, (int) sbyte.MaxValue), (object) (short) 160, (object) new Color(40, 80, (int) byte.MaxValue, (int) sbyte.MaxValue), (object) (short) 20, (object) new Color(40, (int) byte.MaxValue, 80, (int) sbyte.MaxValue));
      public static List<int> Skeletons = new List<int>()
      {
        77,
        -49,
        -51,
        -53,
        -47,
        449,
        450,
        451,
        452,
        481,
        201,
        -15,
        202,
        203,
        21,
        324,
        110,
        323,
        293,
        291,
        322,
        -48,
        -50,
        -52,
        -46,
        292,
        197,
        167,
        44
      };
      public static int[] BossHeadTextures = NPCID.Sets.Factory.CreateIntSet(-1, 4, 0, 13, 2, 344, 3, 370, 4, 246, 5, 249, 5, 345, 6, 50, 7, 396, 8, 395, 9, 325, 10, 262, 11, 327, 13, 222, 14, 125, 15, 126, 16, 346, 17, (int) sbyte.MaxValue, 18, 35, 19, 68, 19, 113, 22, 266, 23, 439, 24, 440, 24, 134, 25, 491, 26, 517, 27, 422, 28, 507, 29, 493, 30, 549, 35, 564, 32, 565, 32, 576, 33, 577, 33, 551, 34, 548, 36);
      public static bool[] ExcludedFromDeathTally = NPCID.Sets.Factory.CreateBoolSet(false, 121, 384, 406);
      public static bool[] TechnicallyABoss = NPCID.Sets.Factory.CreateBoolSet(517, 422, 507, 493, 399);
      public static bool[] MustAlwaysDraw = NPCID.Sets.Factory.CreateBoolSet(113, 114, 115, 116, 126, 125);
      public static int[] ExtraTextureCount = NPCID.Sets.Factory.CreateIntSet(0, 38, 1, 17, 1, 107, 0, 19, 0, 22, 0, 124, 1, 228, 0, 178, 1, 18, 1, 229, 1, 209, 1, 54, 1, 108, 1, 160, 0, 20, 0, 369, 1, 453, 1, 368, 1, 207, 1, 227, 1, 208, 0, 142, 1, 441, 1, 353, 1, 550, 0);
      public static int[] NPCFramingGroup = NPCID.Sets.Factory.CreateIntSet(0, 18, 1, 20, 1, 208, 1, 178, 1, 124, 1, 353, 1, 369, 2, 160, 3);
      public static int[][] TownNPCsFramingGroups = new int[4][]
      {
        new int[26]
        {
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        },
        new int[25]
        {
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        },
        new int[25]
        {
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          -2,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0
        },
        new int[23]
        {
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          -2,
          -2,
          -2,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          0,
          2,
          6
        }
      };
    }
  }
}
