import os
import sys
import xml.etree.ElementTree as ET


site_packages = os.path.join(os.path.dirname(sys.executable),'Lib', 'site-packages' '..')
if site_packages in sys.path:
    sys.path.append(site_packages)

# ---------- ДАННЫЕ ТУРНИРА ----------

def generate(output_path : str):
    tournament_data = {
        "name": "лично-командных соревнований по спортивной ловле рыбы со льда на зимнюю удочку с мормышкой",
        "description": 'чемпионат мира 17-18 марта 2001г.Россия, Москва, гребной канал "Крылатское"',
        "teams": [
            {
                "name": "ФИНЛЯНДИЯ", "id": "1",
                "fishers": [
                    {"name": "Хенри Хуттунен", "tours": [
                        {"Zone": "C", "Weight": "317", "Place": "7"},
                        {"Zone": "A", "Weight": "543", "Place": "6"}
                    ]},
                    {"name": "Сату Паполяки", "tours": [
                        {"Zone": "A", "Weight": "499", "Place": "4"},
                        {"Zone": "D", "Weight": "185", "Place": "7"}
                    ]},
                    {"name": "Терту Кота-Ахо", "tours": [
                        {"Zone": "D", "Weight": "164", "Place": "7"},
                        {"Zone": "E", "Weight": "391", "Place": "6"}
                    ]},
                    {"name": "Ристо Мяенля", "tours": [
                        {"Zone": "E", "Weight": "258", "Place": "6"},
                        {"Zone": "A", "Weight": "138", "Place": "7"}
                    ]},
                    {"name": "Марти Пёлпянен", "tours": [
                        {"Zone": "B", "Weight": "174", "Place": "7"},
                        {"Zone": "B", "Weight": "685", "Place": "5"}
                    ]}
                ]
            },
            {
                "name": "КАНАДА", "id": "2",
                "fishers": [
                    {"name": "Барри Лупола", "tours": [
                        {"Zone": "C", "Weight": "365", "Place": "5"},
                        {"Zone": "A", "Weight": "341", "Place": "7"}
                    ]},
                    {"name": "Дэйн Мак Кой", "tours": [
                        {"Zone": "E", "Weight": "195", "Place": "7"},
                        {"Zone": "B", "Weight": "482", "Place": "7"}
                    ]},
                    {"name": "Кориен Юпт", "tours": [
                        {"Zone": "B", "Weight": "452", "Place": "5"},
                        {"Zone": "E", "Weight": "319", "Place": "6"}
                    ]},
                    {"name": "Дэнис Пориски", "tours": [
                        {"Zone": "A", "Weight": "258", "Place": "7"},
                        {"Zone": "C", "Weight": "176", "Place": "6"}
                    ]},
                    {"name": "Дэрил Самикия", "tours": [
                        {"Zone": "D", "Weight": "778", "Place": "4"},
                        {"Zone": "D", "Weight": "807", "Place": "3"}
                    ]},
                    {"name": "Клифф Конверт", "tours": [
                        {"Zone": "-", "Weight": "-", "Place": "-"},
                        {"Zone": "-", "Weight": "-", "Place": "-"}
                    ]}
                ]
            },
            {
                "name": "УКРАИНА", "id": "3",
                "fishers": [
                    {"name": "Сергей Бурдак", "tours": [
                        {"Zone": "B", "Weight": "486", "Place": "6"},
                        {"Zone": "E", "Weight": "615", "Place": "5"}
                    ]},
                    {"name": "Юрий Кухарь", "tours": [
                        {"Zone": "E", "Weight": "301", "Place": "5"},
                        {"Zone": "B", "Weight": "485", "Place": "6"}
                    ]},
                    {"name": "Владимир Сакало", "tours": [
                        {"Zone": "A", "Weight": "468", "Place": "5"},
                        {"Zone": "D", "Weight": "262", "Place": "6"}
                    ]},
                    {"name": "Анатолий Тихонов", "tours": [
                        {"Zone": "C", "Weight": "355", "Place": "6"},
                        {"Zone": "A", "Weight": "351", "Place": "5"}
                    ]},
                    {"name": "Константин Тищевский", "tours": [
                        {"Zone": "D", "Weight": "451", "Place": "6"},
                        {"Zone": "C", "Weight": "213", "Place": "5"}
                    ]}
                ]
            },
            {
                "name": "ЛАТВИЯ", "id": "4",
                "fishers": [
                    {"name": "Гунтис Каркишнис", "tours": [
                        {"Zone": "C", "Weight": "1248", "Place": "1"},
                        {"Zone": "A", "Weight": "1510", "Place": "2"}
                    ]},
                    {"name": "Василий Арехин", "tours": [
                        {"Zone": "B", "Weight": "926", "Place": "3"},
                        {"Zone": "C", "Weight": "821", "Place": "2"}
                    ]},
                    {"name": "Евгений Григорьев", "tours": [
                        {"Zone": "E", "Weight": "1116", "Place": "3"},
                        {"Zone": "E", "Weight": "1313", "Place": "1"}
                    ]},
                    {"name": "Петерис Лидерис", "tours": [
                        {"Zone": "A", "Weight": "894", "Place": "4"},
                        {"Zone": "B", "Weight": "1114", "Place": "2"}
                    ]},
                    {"name": "Леонид Панков", "tours": [
                        {"Zone": "D", "Weight": "746", "Place": "3"},
                        {"Zone": "D", "Weight": "1301", "Place": "2"}
                    ]},
                    {"name": "Рита Вязра", "tours": [
                        {"Zone": "D", "Weight": "746", "Place": "3"},
                        {"Zone": "D", "Weight": "1301", "Place": "2"}
                    ]}
                ]
            },
            {
                "name": "БЕЛОРУССИЯ", "id": "5",
                "fishers": [
                    {"name": "Петр Нагула", "tours": [
                        {"Zone": "B", "Weight": "391", "Place": "6"},
                        {"Zone": "B", "Weight": "574", "Place": "4"}
                    ]},
                    {"name": "Андрей Кишкурно", "tours": [
                        {"Zone": "E", "Weight": "452", "Place": "5"},
                        {"Zone": "E", "Weight": "1034", "Place": "3"}
                    ]},
                    {"name": "Сергей Левизов", "tours": [
                        {"Zone": "A", "Weight": "734", "Place": "4"},
                        {"Zone": "A", "Weight": "907", "Place": "4"}
                    ]},
                    {"name": "Юрий Щорс", "tours": [
                        {"Zone": "C", "Weight": "1007", "Place": "3"},
                        {"Zone": "C", "Weight": "1450", "Place": "1"}
                    ]},
                    {"name": "Владимир Яковлев", "tours": [
                        {"Zone": "D", "Weight": "543", "Place": "6"},
                        {"Zone": "D", "Weight": "607", "Place": "4"}
                    ]},
                    {"name": "Игорь Гусенков", "tours": [
                        {"Zone": "-", "Weight": "-", "Place": "-"},
                        {"Zone": "-", "Weight": "-", "Place": "-"}
                    ]}
                ]
            },
            {
                "name": "ШВЕЦИЯ", "id": "6",
                "fishers": [
                    {"name": "Ханс-Эрик Кристофферс", "tours": [
                        {"Zone": "A", "Weight": "804", "Place": "3"},
                        {"Zone": "B", "Weight": "1096", "Place": "3"}
                    ]},
                    {"name": "Томас Альксон", "tours": [
                        {"Zone": "C", "Weight": "678", "Place": "4"},
                        {"Zone": "C", "Weight": "875", "Place": "3"}
                    ]},
                    {"name": "Петер Эриксон", "tours": [
                        {"Zone": "B", "Weight": "569", "Place": "5"},
                        {"Zone": "B", "Weight": "798", "Place": "4"}
                    ]},
                    {"name": "Фольк Андерсон", "tours": [
                        {"Zone": "D", "Weight": "467", "Place": "5"},
                        {"Zone": "D", "Weight": "876", "Place": "2"}
                    ]},
                    {"name": "Ове Эриксон", "tours": [
                        {"Zone": "E", "Weight": "621", "Place": "4"},
                        {"Zone": "A", "Weight": "843", "Place": "4"}
                    ]},
                    {"name": "Берндт Бергрен", "tours": [
                        {"Zone": "-", "Weight": "-", "Place": "-"},
                        {"Zone": "-", "Weight": "-", "Place": "-"}
                    ]}
                ]
            },
            {
                "name": "РОССИЯ", "id": "7",
                "fishers": [
                    {"name": "Михаил Дунин", "tours": [
                        {"Zone": "B", "Weight": "1449", "Place": "1"},
                        {"Zone": "A", "Weight": "1445", "Place": "1"}
                    ]},
                    {"name": "Алексей Дьяченко", "tours": [
                        {"Zone": "A", "Weight": "1152", "Place": "1"},
                        {"Zone": "D", "Weight": "1485", "Place": "1"}
                    ]},
                    {"name": "Максим Дыдыкин", "tours": [
                        {"Zone": "D", "Weight": "1283", "Place": "2"},
                        {"Zone": "B", "Weight": "1295", "Place": "2"}
                    ]},
                    {"name": "Максим Кусмарцев", "tours": [
                        {"Zone": "C", "Weight": "1441", "Place": "1"},
                        {"Zone": "C", "Weight": "1266", "Place": "2"}
                    ]},
                    {"name": "Сергей Кусмарцев", "tours": [
                        {"Zone": "E", "Weight": "1233", "Place": "2"},
                        {"Zone": "E", "Weight": "1296", "Place": "2"}
                    ]},
                    {"name": "Павел Ржанов", "tours": [
                        {"Zone": "E", "Weight": "2429", "Place": "1"},
                        {"Zone": "-", "Weight": "2834", "Place": "1"}
                    ]}
                ]
            }
        ]
    }
    root = build_tournament_xml(tournament_data)
    tree = ET.ElementTree(root)
    tree.write(output_path, encoding="utf-8", xml_declaration=True)
    #print("✅ Файл 'tournament.xml' успешно создан!")


# ---------- ГЕНЕРАЦИЯ XML ----------
def build_tournament_xml(data):
    tournament = ET.Element("Tournament", name=data["name"])
    ET.SubElement(tournament, "Description").text = data["description"]

    for team_data in data["teams"]:
        team = ET.SubElement(tournament, "Team", name=team_data["name"], id=team_data["id"])
        fishers = ET.SubElement(team, "Fishers")

        for fisher_data in team_data["fishers"]:
            fisher = ET.SubElement(fishers, "Fisher", name=fisher_data["name"])
            for i, tour in enumerate(fisher_data["tours"], 1):
                tour_el = ET.SubElement(fisher, f"Tour{i}")
                for key, value in tour.items():
                    ET.SubElement(tour_el, key).text = value
    return tournament

# ---------- СОХРАНЕНИЕ В ФАЙЛ ----------



