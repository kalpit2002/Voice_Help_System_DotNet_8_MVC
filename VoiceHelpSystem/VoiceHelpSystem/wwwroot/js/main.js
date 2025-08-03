import * as THREE from 'three';
import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';
let mixer;

const renderer = new THREE.WebGLRenderer({ anlpha: true });
renderer.outputColorSpace = THREE.SRGBColorSpace;

renderer.setSize(window.innerWidth, window.innerHeight);
renderer.setClearColor(0x000000);
renderer.setPixelRatio(window.devicePixelRatio);

renderer.shadowMap.enabled = true;
renderer.shadowMap.type = THREE.PCFSoftShadowMap;

document.body.appendChild(renderer.domElement);

const scene = new THREE.Scene();


const camera = new THREE.PerspectiveCamera(65, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.position.set(10, 5, 20);



const controls = new OrbitControls(camera, renderer.domElement);
controls.enableDamping = true;
controls.enablePan = true;
controls.minDistance = 300;
controls.maxDistance = 1000;
controls.minPolarAngle = 0;
controls.maxPolarAngle = Math.PI;
controls.autoRotate = false;
controls.update();





// const ambientLight = new THREE.AmbientLight(0xfffff,2)
// scene.add(ambientLight);
const spotLight = new THREE.DirectionalLight(0xffffff,4);
spotLight.position.set(50000, 50000, 50000);


scene.add(spotLight);


const loader = new GLTFLoader()
loader.load('../images/threedmo/untitled.glb', (gltf) => {
   
  console.log('loading model');
  console.log(gltf.animations);
  const mesh = gltf.scene;
  mixer = new THREE.AnimationMixer(mesh);
  // mixer.clipAction(gltf.animations[0]).play();
  // mixer.clipAction(gltf.animations[47]).play();
  

  mesh.traverse((child) => {
    if (child.isMesh) {
      child.castShadow = true;
      child.receiveShadow = true;
    }
  });

  // mesh.position.set(5, -20, 5);
  mesh.position.set(0, 0, 0);
  mesh.rotation.y =0.5; 
  scene.add(mesh);

  document.getElementById('progress-container').style.display = 'none';

}, (xhr) => {
  console.log(`loading ${xhr.loaded / xhr.total * 100}%`);
}, (error) => {
  console.error(error);
});

window.addEventListener('resize', () => {
  camera.aspect = window.innerWidth / window.innerHeight;
  camera.updateProjectionMatrix();
  renderer.setSize(window.innerWidth, window.innerHeight);
});

function animate() {
  requestAnimationFrame(animate);
  controls.update();
  renderer.render(scene, camera);
  
  mixer.update(0.02);
  
}



animate();