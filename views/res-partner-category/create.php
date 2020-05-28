<?php

use yii\helpers\Html;


$this->title = 'Create Res Partner Category';
$this->params['breadcrumbs'][] = ['label' => 'Res Partner Categories', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-partner-category-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>