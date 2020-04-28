#version 400 core

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 transformation_matrix;

layout(location = 0) in vec3 position;
layout(location = 1) in vec2 textureCoords;

out vec2 pass_textureCoords;
 
void main(void)
{
  gl_Position = vec4(position, 1.) * transformation_matrix * view_matrix *  projection_matrix;
  pass_textureCoords = textureCoords;
}