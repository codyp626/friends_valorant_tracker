import json
import requests


userList =[ 
        "shua/9731", 
        "spit%20slurpin/2222", 
        "Pepp/fishi", 
        "ZeroTwo/2809", 
        "Jsav16/9925", 
        "cadennedac/na1", 
        "augdog922/2884", 
        "mingemuncher14/misa", 
        "BootyConsumer/376", 
        "Brewt/0000", 
        "Stroup22/na1", 
        "WildKevDog/house",
        "Validation/hater"
        ]

headers = {'Authorization': 'HDEV-a6a18b29-ca0d-4332-be8f-37d2eacd1a5d',}

for user in userList:
    # url = "https://api.henrikdev.xyz/valorant/v1/mmr-history/na/" + user
    url = "https://api.henrikdev.xyz/valorant/v1/stored-mmr-history/na/" + user + "?size=20"

    response = requests.request("GET", url, headers=headers).json()
    print(user , "has" , len(response["data"]) , "games")
    # print("last game for", user, "on", response["data"][0]["date"])
