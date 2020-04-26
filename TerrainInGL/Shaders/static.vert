#version 400 core

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 transformation_matrix;

layout(location = 0) in vec3 position;

out vec3 color;
 
void main(void)
{
  gl_Position = vec4(poosition, 0, 1) * transformation_matrix  * view_matrix * projection_matrix;
  color = vec3(position.x+0.5, position.z+0.5, position.y+0.5);
}