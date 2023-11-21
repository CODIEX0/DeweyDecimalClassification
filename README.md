# DeweyDecimalClassification
A Dewey Decimal Classification app to make learning about the Dewey Decimal system more fun and engaging.

<div class="dewey-decimal-animation">
  <span class="bounce">D</span>
  <span class="bounce">2</span>
  <span class="bounce">3</span>
  <span class="bounce">5</span>
  <span class="bounce">.</span>
  <span class="bounce">7</span>
</div>

<style>
.dewey-decimal-animation {
  display: flex;
  font-size: 2em;
}

.bounce {
  animation: bounce 1s infinite alternate;
}

@keyframes bounce {
  0% {
    transform: translateY(0);
  }
  100% {
    transform: translateY(-10px);
  }
}
</style>

