<?php

use yii\helpers\Html;

$this->title = 'Crear ';
$this->params['breadcrumbs'][] = ['label' => 'Categorias de Productos', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="product-category-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
