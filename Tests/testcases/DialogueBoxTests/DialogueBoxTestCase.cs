﻿using Tests.Head;
using Tests.Head.GenericElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Graphics.UI;

namespace Tests.testcases.DialogueBoxTests
{
    public class DialogueBoxTestCase : testcase
    {
        Game game;

        button button_messagebox;
        DialogueBox messagebox;

        public DialogueBoxTestCase(Game Game) : base (Game)
        {
            testcasename = "DialogueBoxes";
            game = Game;
        }

        public override void LoadContent()
        {
            button_messagebox = new button(game)
            {
                label = "button_messagebox",
                rect = new Rectangle(300, 300, 200, 50)
            };
            button_messagebox.LoadContent();

            messagebox = new DialogueBox()
            {
                Type = DialogueBox.type.message,
                message = "this is a dialoguebox",
                title = "facts",
                font = game.Content.Load<SpriteFont>("font"),
                TitleAlign = DialogueBox.Align.Middle,
                MessageAlign = DialogueBox.Align.Left,
                window = new Pane()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    rect = new Rectangle (1366 / 2 - 400 / 2, 768 / 2 - 100 / 2, 400, 100),
                    color = Color.White
                },
                selectionButton = new Button()
                {
                    buttonLeft = game.Content.Load<Texture2D>("button/left"),
                    buttonMiddle = game.Content.Load<Texture2D>("button/middle"),
                    buttonRight = game.Content.Load<Texture2D>("button/right"),
                    labelFont = game.Content.Load<SpriteFont>("font"),
                    rect = new Rectangle (0, 0, 120, 20)
                },
            };
            messagebox.visible = false;

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            button_messagebox.Update();
            messagebox.Update();

            if (button_messagebox.pressed)
            {
                messagebox.visible = true;
                button_messagebox.pressed = false;
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            button_messagebox.Draw(spritebatch);
            messagebox.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
