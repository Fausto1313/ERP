<?php

use yii\helpers\Html;


$this->title = 'Crear Compañia';
$this->params['breadcrumbs'][] = ['label' => 'Compañia', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-company-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
