#version 400
uniform samplerCube tex;
uniform sampler2D meshMap;
in vec2 texCoord;
out vec4 fragColor;

void main()
{
  vec4 vector = texture(meshMap, texCoord);
  vec4 texel = texture(tex, vector.yxz);
  fragColor = texel;
}
