#version 400
uniform mat4 modelview;
uniform mat4 projection;
layout(location = 0) in vec3 vp; // vertex position (for each vertex in obj file)
layout(location = 1) in vec3 vn; // vertex texture coordinate ("")
layout(location = 2) in vec3 vo; // instance attribute (vertex offset)
out vec3 position;
out vec3 normal;

void main()
{
  mat4 normalmat = transpose(inverse(modelview));
  vec4 v = modelview * vec4(vp + vo, 1.0);
  gl_Position = projection * v;
  position = vec3(v);
  normal = normalize(vec3(normalmat * vec4(vn, 0.0)));
}