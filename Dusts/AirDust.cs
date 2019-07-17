using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WolfsAdditions.Dusts
{
    public class AirDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.velocity *= 0.5f;
            dust.velocity.Y -= 0.5f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.1f;
            dust.scale -= 0.02f;
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            /*
            if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10))
            {
                dust.scale *= 0.9f;
                dust.velocity = new Vector2(0, 0);
            }
            */
            return false;
        }
    }
}