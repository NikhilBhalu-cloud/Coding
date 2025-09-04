(function () {
  "use strict";

  // Theme management
  const themeToggle = document.getElementById("theme-toggle");
  const body = document.body;
  const themeKey = "csharp_learning_theme";

  function updateThemeIcon(theme) {
    if (themeToggle) {
      const icon = themeToggle.querySelector("i");
      if (icon) {
        icon.className =
          theme === "dark" ? "bi bi-sun-fill" : "bi bi-moon-fill";
      }
    }
  }

  function applyTheme(theme) {
    if (theme === "dark") {
      body.classList.add("dark");
    } else {
      body.classList.remove("dark");
    }
    updateThemeIcon(theme);

    // Update navbar and other elements
    const navbar = document.querySelector(".navbar");
    if (navbar) {
      if (theme === "dark") {
        navbar.classList.replace("navbar-light", "navbar-dark");
      } else {
        navbar.classList.replace("navbar-dark", "navbar-light");
      }
    }
  }

  // Load saved theme
  const savedTheme = localStorage.getItem(themeKey) || "light";
  applyTheme(savedTheme);

  // Theme toggle event
  if (themeToggle) {
    themeToggle.addEventListener("click", () => {
      const currentTheme = body.classList.contains("dark") ? "dark" : "light";
      const newTheme = currentTheme === "dark" ? "light" : "dark";
      applyTheme(newTheme);
      localStorage.setItem(themeKey, newTheme);
    });
  }

  // Sidebar toggle functionality with enhanced features
  const sidebarToggle = document.getElementById("sidebarToggle");
  const sidebar = document.getElementById("sidebar");
  const sidebarSearch = document.getElementById("sidebarSearch");

  if (sidebarToggle && sidebar) {
    sidebarToggle.addEventListener("click", () => {
      sidebar.classList.toggle("show");
      
      // Add overlay for mobile
      if (window.innerWidth <= 992) {
        toggleOverlay();
      }
    });

    // Close sidebar when clicking outside on mobile
    document.addEventListener("click", (e) => {
      if (window.innerWidth <= 992 && 
          !sidebar.contains(e.target) && 
          !sidebarToggle.contains(e.target) &&
          sidebar.classList.contains("show")) {
        sidebar.classList.remove("show");
        removeOverlay();
      }
    });
  }

  // Enhanced sidebar search functionality
  if (sidebarSearch) {
    sidebarSearch.addEventListener("input", function() {
      const searchTerm = this.value.toLowerCase();
      const topicItems = document.querySelectorAll('.topic-item');
      const topicSections = document.querySelectorAll('.topic-section');
      
      topicItems.forEach(item => {
        const text = item.textContent.toLowerCase();
        const section = item.closest('.topic-section');
        
        if (text.includes(searchTerm)) {
          item.style.display = '';
          section.classList.remove('collapsed');
        } else {
          item.style.display = 'none';
        }
      });
      
      // Hide sections with no visible items
      topicSections.forEach(section => {
        const visibleItems = section.querySelectorAll('.topic-item[style=""], .topic-item:not([style])');
        if (searchTerm && visibleItems.length === 0) {
          section.style.display = 'none';
        } else {
          section.style.display = '';
        }
      });
    });
  }

  // Collapsible section functionality
  window.toggleSection = function(sectionName) {
    const section = document.querySelector(`[data-section="${sectionName}"]`);
    if (section) {
      section.classList.toggle('collapsed');
      
      // Save state to localStorage
      const collapsed = section.classList.contains('collapsed');
      localStorage.setItem(`section-${sectionName}`, collapsed ? 'true' : 'false');
    }
  };

  // Restore section states from localStorage
  function restoreSectionStates() {
    const sections = document.querySelectorAll('.topic-section[data-section]');
    sections.forEach(section => {
      const sectionName = section.getAttribute('data-section');
      const isCollapsed = localStorage.getItem(`section-${sectionName}`) === 'true';
      
      if (isCollapsed) {
        section.classList.add('collapsed');
      }
    });
  }

  // Mobile overlay functions
  function toggleOverlay() {
    let overlay = document.querySelector('.sidebar-overlay');
    if (!overlay) {
      overlay = document.createElement('div');
      overlay.className = 'sidebar-overlay';
      document.body.appendChild(overlay);
      
      overlay.addEventListener('click', () => {
        sidebar.classList.remove('show');
        removeOverlay();
      });
    }
  }

  function removeOverlay() {
    const overlay = document.querySelector('.sidebar-overlay');
    if (overlay) {
      overlay.remove();
    }
  }

  // Initialize section states
  restoreSectionStates();

  // Smooth scrolling for sidebar links
  document.querySelectorAll('.sidebar a[href^="#"]').forEach((anchor) => {
    anchor.addEventListener("click", function (e) {
      e.preventDefault();
      const target = document.querySelector(this.getAttribute("href"));
      if (target) {
        const offsetTop = target.getBoundingClientRect().top + window.pageYOffset - 100;
        window.scrollTo({
          top: offsetTop,
          behavior: "smooth",
        });
        
        // Close sidebar on mobile after clicking
        if (window.innerWidth <= 992 && sidebar) {
          sidebar.classList.remove("show");
        }
        
        // Update active link
        document.querySelectorAll('.sidebar .nav-link').forEach(link => {
          link.classList.remove('active');
        });
        this.classList.add('active');
      }
    });
  });

  // Auto-highlight current section in sidebar
  function updateSidebarActiveLink() {
    const sections = document.querySelectorAll('section[id]');
    const sidebarLinks = document.querySelectorAll('.sidebar .nav-link[href^="#"]');
    
    let currentSection = '';
    sections.forEach(section => {
      const rect = section.getBoundingClientRect();
      if (rect.top <= 150 && rect.bottom >= 150) {
        currentSection = section.id;
      }
    });
    
    sidebarLinks.forEach(link => {
      link.classList.remove('active');
      if (link.getAttribute('href') === `#${currentSection}`) {
        link.classList.add('active');
      }
    });
  }

  window.addEventListener('scroll', updateSidebarActiveLink);
  updateSidebarActiveLink(); // Initial call


  // Code copy functionality
  function addCopyButtons() {
    const codeBlocks = document.querySelectorAll("pre code");
    codeBlocks.forEach((codeBlock, index) => {
      const pre = codeBlock.parentElement;
      const copyButton = document.createElement("button");
      copyButton.className =
        "btn btn-sm btn-outline-secondary position-absolute top-0 end-0 m-2";
      copyButton.innerHTML = '<i class="bi bi-clipboard"></i>';
      copyButton.style.fontSize = "0.75rem";
      copyButton.title = "Copy code";

      pre.style.position = "relative";
      pre.appendChild(copyButton);

      copyButton.addEventListener("click", async () => {
        try {
          await navigator.clipboard.writeText(codeBlock.textContent);
          copyButton.innerHTML = '<i class="bi bi-check"></i>';
          copyButton.classList.replace("btn-outline-secondary", "btn-success");

          setTimeout(() => {
            copyButton.innerHTML = '<i class="bi bi-clipboard"></i>';
            copyButton.classList.replace(
              "btn-success",
              "btn-outline-secondary"
            );
          }, 2000);
        } catch (err) {
          console.error("Failed to copy: ", err);
        }
      });
    });
  }

  // Add copy buttons after page load
  document.addEventListener("DOMContentLoaded", addCopyButtons);

  // Table of contents active link highlighting
  function highlightTOC() {
    const sections = document.querySelectorAll("section[id]");
    const tocLinks = document.querySelectorAll('.nav-link[href^="#"]');

    function updateActiveTOC() {
      let current = "";
      sections.forEach((section) => {
        const sectionTop = section.getBoundingClientRect().top;
        if (sectionTop <= 100) {
          current = section.getAttribute("id");
        }
      });

      tocLinks.forEach((link) => {
        link.classList.remove("active", "fw-bold");
        if (link.getAttribute("href") === `#${current}`) {
          link.classList.add("active", "fw-bold");
        }
      });
    }

    window.addEventListener("scroll", updateActiveTOC);
    updateActiveTOC(); // Initial call
  }

  // Initialize TOC highlighting if sections exist
  if (document.querySelectorAll("section[id]").length > 0) {
    highlightTOC();
  }

  // Fade in animation for cards
  function animateCards() {
    const cards = document.querySelectorAll(".card");
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            entry.target.classList.add("fade-in-up");
          }
        });
      },
      { threshold: 0.1 }
    );

    cards.forEach((card) => {
      observer.observe(card);
    });
  }

  // Initialize animations
  document.addEventListener("DOMContentLoaded", animateCards);

  // Search functionality (basic)
  function initSearch() {
    const searchInput = document.getElementById("search");
    if (searchInput) {
      searchInput.addEventListener("input", function () {
        const query = this.value.toLowerCase();
        const searchableElements = document.querySelectorAll(
          "h1, h2, h3, h4, h5, h6, p, code"
        );

        searchableElements.forEach((element) => {
          const text = element.textContent.toLowerCase();
          const parent = element.closest(".card, section");
          if (parent) {
            if (text.includes(query) || query === "") {
              parent.style.display = "";
              element.style.backgroundColor = "";
              if (query && text.includes(query)) {
                element.style.backgroundColor = "yellow";
              }
            } else {
              parent.style.display = "none";
            }
          }
        });
      });
    }
  }

  initSearch();

  // Progress indicator for long pages
  function addProgressIndicator() {
    if (document.body.scrollHeight > window.innerHeight * 2) {
      const progressBar = document.createElement("div");
      progressBar.style.cssText = `
                position: fixed;
                top: 0;
                left: 0;
                width: 0%;
                height: 3px;
                background: linear-gradient(90deg, #007bff, #28a745);
                z-index: 9999;
                transition: width 0.1s ease;
            `;
      document.body.appendChild(progressBar);

      window.addEventListener("scroll", () => {
        const scrollPercent =
          (window.scrollY / (document.body.scrollHeight - window.innerHeight)) *
          100;
        progressBar.style.width = Math.min(scrollPercent, 100) + "%";
      });
    }
  }

  document.addEventListener("DOMContentLoaded", addProgressIndicator);
})();
