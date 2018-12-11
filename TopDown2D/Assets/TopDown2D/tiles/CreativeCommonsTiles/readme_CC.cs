/*Readme regarding Crerative commons Files
 * 
 * creative commons artwork is owned be the public domain, as in everyone...
 * the can be limitations imposed be the creator on how there artwork is used
 * and there are different versions of the licenses. more infor can be found at
 * https://creativecommons.org/licenses/by/2.0/
 * 
 * 
 * pixle art emulates the rendered graphics capibilities of the 1980s console games 
 * before polygon based graphics and shaders where possible in realtime rendering.
 * 
 * "Pixle art" today is a distint art style, where the minimum detail resolution is the same for all art elements, 
 * in other words the pixel size for each sprit is the same size. 
 *  
 * 
 * for sprite sheets, there are several sprites on the same texture, some texture settings that should be adjusted after import 
 * 
 * Sprite mode: multiple 
 * pixels per unit should match the sprite pixle density (ppu 16, spritesheet should mostly be cut into 16*16px tiles)
 * 
 * for pixle art, there should be no texture filter, since the desired rendered pixle output is the pixle point of the sprite (no blending)
 * filter mode: point(no filter)
 * 
 * for tiled environments that used the Grid and Grid Renderer components in the 2d-extras package from Github.com/Unity-Technologies
 * you may need to make a sprite atlas to avoid gaps caused by to floating points in the camera position and render depths
 * creating gaps in the tilegrid.(sorry, computers arn't magic)
 * 
 * 
 * 
 * 
 * 
 * 
 */
