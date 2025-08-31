// Navigation interaction
const navLinks = document.querySelectorAll('.nav-item');
const sections = ['home', 'about', 'services','product', 'contact'];
const hamburger = document.getElementById('hamburger');
const navLinksContainer = document.getElementById('nav-links');
const learnMoreBtn = document.getElementById('learn-more-btn');

function setActiveSection(targetId) {
  sections.forEach((secId) => {
    const sec = document.getElementById(secId);
    if (secId === targetId) {
      sec.style.display = 'block';
    } else {
      sec.style.display = 'none';
    }
  });
  navLinks.forEach(link => {
    link.classList.toggle('active', link.dataset.target === targetId);
  });
}

navLinks.forEach(link => {
  link.addEventListener('click', () => {
    setActiveSection(link.dataset.target);
    if (navLinksContainer.classList.contains('open')) {
      navLinksContainer.classList.remove('open');
      hamburger.setAttribute('aria-expanded', 'false');
    }
    window.scrollTo({ top: 0, behavior: 'smooth' });
  });
  link.addEventListener('keydown', e => {
    if (e.key === 'Enter' || e.key === ' ') {
      e.preventDefault();
      link.click();
    }
  });
});

hamburger.addEventListener('click', () => {
  navLinksContainer.classList.toggle('open');
  const expanded = hamburger.getAttribute('aria-expanded') === 'true';
  hamburger.setAttribute('aria-expanded', String(!expanded));
});
hamburger.addEventListener('keydown', e => {
  if (e.key === 'Enter' || e.key === ' ') {
    e.preventDefault();
    hamburger.click();
  }
});

learnMoreBtn.addEventListener('click', () => {
  setActiveSection('about');
  window.scrollTo({ top: 0, behavior: 'smooth' });
});

// Contact form submission interaction
const contactForm = document.getElementById('contactForm');
const contactHelpText = document.getElementById('contactHelpText');

contactForm.addEventListener('submit', function(e) {
  e.preventDefault();
  contactHelpText.style.display = 'block';
  contactForm.reset();
  setTimeout(() => {
    contactHelpText.style.display = 'none';
  }, 5000);
});

// Initialize default section
setActiveSection('home');

// Background canvas for interactive particles
const canvas = document.getElementById('background-canvas');
const ctx = canvas.getContext('2d');
let width, height;
let particlesArray = [];
const particleCount = 60;

class Particle {
  constructor() {
    this.reset();
  }
  reset() {
    this.x = Math.random() * width;
    this.y = Math.random() * height;
    this.size = 2 + Math.random() * 3;
    this.speedX = (Math.random() - 0.5) * 0.7;
    this.speedY = (Math.random() - 0.5) * 0.7;
    this.opacity = 0.1 + Math.random() * 0.3;
    this.color = 'rgba(0, 173, 181, ' + this.opacity + ')';
  }
  update(mouse) {
    this.x += this.speedX;
    this.y += this.speedY;

    // Wrap around edges
    if (this.x < 0) this.x = width;
    if (this.x > width) this.x = 0;
    if (this.y < 0) this.y = height;
    if (this.y > height) this.y = 0;

    // Repel from mouse
    if (mouse.x && mouse.y) {
      let dx = this.x - mouse.x;
      let dy = this.y - mouse.y;
      let dist = Math.sqrt(dx * dx + dy * dy);
      if (dist < 100) {
        let angle = Math.atan2(dy, dx);
        let repelForce = (100 - dist) / 100 * 2;
        this.x += Math.cos(angle) * repelForce;
        this.y += Math.sin(angle) * repelForce;
      }
    }
  }
  draw() {
    ctx.beginPath();
    ctx.fillStyle = this.color;
    ctx.shadowColor = 'rgba(0, 255, 200, 0.7)';
    ctx.shadowBlur = 10;
    ctx.arc(this.x, this.y, this.size, 0, Math.PI * 2);
    ctx.fill();
  }
}

function init() {
  resizeCanvas();
  particlesArray = [];
  for (let i = 0; i < particleCount; i++) {
    particlesArray.push(new Particle());
  }
}

function resizeCanvas() {
  width = window.innerWidth;
  height = window.innerHeight;
  canvas.width = width;
  canvas.height = height;
}

const mouse = { x: null, y: null };

window.addEventListener('resize', init);
window.addEventListener('mousemove', function(e) {
  mouse.x = e.clientX;
  mouse.y = e.clientY;
});
window.addEventListener('mouseout', function() {
  mouse.x = null;
  mouse.y = null;
});

function animate() {
  ctx.clearRect(0, 0, width, height);
  particlesArray.forEach(p => {
    p.update(mouse);
    p.draw();
  });
  connectParticles();
  requestAnimationFrame(animate);
}

function connectParticles() {
  let maxDistance = 120;
  for (let a = 0; a < particlesArray.length; a++) {
    for (let b = a + 1; b < particlesArray.length; b++) {
      let dx = particlesArray[a].x - particlesArray[b].x;
      let dy = particlesArray[a].y - particlesArray[b].y;
      let dist = Math.sqrt(dx * dx + dy * dy);
      if (dist < maxDistance) {
        ctx.strokeStyle = 'rgba(0, 173, 181,' + (1 - dist / maxDistance) * 0.4 + ')';
        ctx.lineWidth = 1;
        ctx.shadowColor = 'rgba(0, 255, 200, 0.3)';
        ctx.shadowBlur = 8;
        ctx.beginPath();
        ctx.moveTo(particlesArray[a].x, particlesArray[a].y);
        ctx.lineTo(particlesArray[b].x, particlesArray[b].y);
        ctx.stroke();
      }
    }
  }
}

init();
animate();