#version 400 core

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 transformation_matrix;
uniform vec3 scale = vec3(1.0, 1.0, 1.0);

uniform float number_of_rows;
uniform vec2 offset;

layout(location = 0) in vec3 position;
layout(location = 1) in vec2 textureCoords;

out vec2 pass_textureCoords;
 
void main(void)
{
  gl_Position = vec4(position.x * scale.x, position.y * scale.y, position.z * scale.z, 1.) * transformation_matrix * view_matrix *  projection_matrix;
  pass_textureCoords = (textureCoords/number_of_rows) + offset;
}