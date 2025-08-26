import json
import os
from winotify import Notification, audio


with open("../../notification.json", 'r', encoding='utf-8') as arquivo:
    dados = json.load(arquivo)

notificao = Notification(app_id="ToDo - Adventure", title=dados['titulo'], msg=dados['msg'], icon=os.path.join(os.path.abspath('.'),"dg_faceset.png" ))
notificao.set_audio(audio.Reminder, loop=False)
notificao.show()
    