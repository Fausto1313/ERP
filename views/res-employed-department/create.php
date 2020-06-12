<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\ResPartner */

$this->title = 'Crear Departamento';
$this->params['breadcrumbs'][] = ['label' => 'Departamentos', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-employed-department-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
