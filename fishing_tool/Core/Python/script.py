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
           
           
        ]
    }

    root = build_tournament_xml(tournament_data)
    tree = ET.ElementTree(root)
    tree.write(output_path + "/example.XML", encoding="utf-8", xml_declaration=True)
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



