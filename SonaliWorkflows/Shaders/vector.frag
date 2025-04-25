#version 400
uniform sampler2D meshMap;
in vec2 texCoord;
out vec4 fragColor;

void main()
{
  vec4 vector = texture(meshMap, texCoord);
  fragColor = vec4(vector.y,vector.x,vector.z,1);
}
