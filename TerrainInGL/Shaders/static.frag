#version 330

uniform sampler2D sampler;

in vec2 pass_textureCoords;
 
void main(void)
{
  gl_FragColor = texture(sampler, pass_textureCoords);
}