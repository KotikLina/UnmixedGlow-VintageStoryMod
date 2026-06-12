# UnmixedGlow-VintageStoryMod
<details>
  <summary>Russian</summary>
  
  ### Unmixed Glow - Клиентский мод

  Этот мод изменяет стандартную логику смешивания света, исходящего от игрока.
  По умолчанию движок игры пытается математически объединить оттенки всех экипированных предметов (например, факела в руке и амулета с темпоральной шестерёнкой на шее)

  ### Как работает мод:
  Код перехватывает информацию о излучаемом игроком смешанном свете и заменяет его на самый яркий источник света, при этом удаляя информацию об остальных. По итогу, несмотря на наличие у игрока нескольких источников света, будет браться самый яркий.

  ### Для чего может быть полезен мод:
  Если у вас в слотах экипировки есть светящийся предмет, не являющийся основным источником света для освещения (temporal gear amulet), который влияет на излучаемый свет основного источника света (путем смешивания этих цветов) то с этим модом эта проблема исчезнет
  
---
  На скриншоте можно заметить, как убирается смешивание оттенка от факела и temporal gear amulet.
  В примере яркость от Temporal Gear Amulet увиличена. Это делается модом: ConfigurableHandheldLightLevels (Мод пока не загружен).</details>
  
---

<details>
  <summary>English</summary>
  
  ### Unmixed Glow - Client side mod

  This mod changes the standard logic for blending light emitted by the player.
  By default, the game engine attempts to mathematically blend the hues of all equipped items (for example, a torch in the hand and a temporal gear amulet around the neck)

  ### How the mod works:
  The code intercepts information about the mixed light emitted by the player and replaces it with the brightest light source, while removing information about the others. As a result, even if the player has multiple light sources, only the brightest one will be used.

  ### Why this mod might be useful:
  If you have a glowing item in your equipment slots that isn’t the primary light source (such as the Temporal Gear Amulet) and that affects the light emitted by the primary light source (by mixing those colors), this mod will eliminate that issue

---

  In the screenshot, you can see how the color mixing between the torch and the Temporal Gear Amulet is removed.
  In the example, the brightness from the Temporal Gear Amulet is increased. This is done by the mod: ConfigurableHandheldLightLevels (The mod has not been loaded yet).
</details>

---

### I'm not sure if I've translated this correctly into English, so if anything is wrong, please let me know.
### You can find me on the official Vintage Story Discord: kotiklinok#0000
